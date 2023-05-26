using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TelephoneBook
//Рыжков ПР-24 18:02 26.05.2023
//    ╭━╮----┈╭━╮    //Это котик
//┃╭╯┈┃┊┗━━━━━┛┊┃
//┃╰┳┳┫┏━▅╮┊╭━▅┓┃
//┃┫┫┫┫┃┊▉┃┊┃┊▉┃┃ 
//┃┫┫┫╋╰━━┛▅┗━━╯╋
//┃┫┫┫╋┊┊┊┣┻┫┊┊┊╋
//┃┊┊┊╰┈┈┈┈┈┈┈┳━╯
//┃┣┳┳━━┫┣━━┳╭╯
{
    public partial class PhoneBooks :Form
    {
        private PhoneBook phoneBook;
        private string fileName = "Сontacts.txt";
        public PhoneBooks ()
        {
            InitializeComponent();
            phoneBook = new PhoneBook( );
        }
        private void button1_Click (object sender, EventArgs e) //Загузка текстового фала в листбокс
        {
            try
            {
                if (File.Exists(fileName))
                {
                    PhoneBookLoader.Load(phoneBook, fileName);
                    RefreshContactList( );
                }
                else
                {
                    MessageBox.Show("Файл не найден.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при загрузке. " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }      
        private void button2_Click (object sender, EventArgs e) //Сохранение файлового текста
        {
            Save();
        }
        private void Save () //Сохранение файлового текста
        {
            try
            {
                PhoneBookLoader.Save(phoneBook, fileName);
                Application.Restart();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ошибка при сохранении контактов " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button3_Click (object sender, EventArgs e) //Удаление контакта
        {
            if (listBox1.SelectedIndex >= 0)
            {
                string selectedContact = listBox1.SelectedItem.ToString( );
                string [ ] contactDetails = selectedContact.Split('-');
                string contactName = contactDetails [ 0 ].Trim( );
                phoneBook.RemoveContact(contactName);
                RefreshContactList( );
            }
            else
            {
                MessageBox.Show("Выберите контакт для удаления", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void RefreshContactList () //Поиск контакта
        {
            listBox1.Items.Clear( );
            foreach (var contact in phoneBook.GetContacts( ))
            {
                listBox1.Items.Add(contact.Name + " - " + contact.Phone);
            }
        }
        private void button4_Click (object sender, EventArgs e) //Добавление контакта "Имя" "Номер" + проверка на сущ. контакта
        {
            if(phoneBook.Registers)
            {
                string name = textBox1.Text.Trim( );
                string phone = textBox2.Text.Trim( );
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(phone))
                {
                    Contact newContact = new Contact { Name = name, Phone = phone };
                    phoneBook.AddContact(newContact);
                    RefreshContactList( );
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите имя и номер телефона", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Такой пользователь уже есть!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
        private void button5_Click (object sender, EventArgs e) //Выход из приложения
        {
            Application.Exit();
        }
        private void button6_Click (object sender, EventArgs e) //Поиск контакта по имени
        {
            string searchName = textBox3.Text.Trim( );
            if (!string.IsNullOrEmpty(searchName))
            {
                List<Contact> searchResults = phoneBook.SearchContacts(searchName);
                listBox1.Items.Clear( );
                foreach (var contact in searchResults)
                {
                    listBox1.Items.Add(contact.Name + " - " + contact.Phone);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите имя для поиска", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
