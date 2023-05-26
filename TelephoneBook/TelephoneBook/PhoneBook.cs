using System;
using System.Collections.Generic;

namespace TelephoneBook
//    ╭━╮----┈╭━╮    
//┃╭╯┈┃┊┗━━━━━┛┊┃
//┃╰┳┳┫┏━▅╮┊╭━▅┓┃
//┃┫┫┫┫┃┊▉┃┊┃┊▉┃┃ 
//┃┫┫┫╋╰━━┛▅┗━━╯╋
//┃┫┫┫╋┊┊┊┣┻┫┊┊┊╋
//┃┊┊┊╰┈┈┈┈┈┈┈┳━╯
//┃┣┳┳━━┫┣━━┳╭╯
{
    internal class PhoneBook
    {
        private List<Contact> contacts; //контакты
        private bool RegisterS; //проверочка 
        public PhoneBook ()
        {
            contacts = new List<Contact>( );
            RegisterS = false;
        }
        public bool Registers //Проверочк на рег. контакта
        {
            get
            {
                return RegisterS;
            }
        }
        public void AddContact (Contact contact) //Добавление контакта
        {
            contacts.Add(contact);
        }
        public void RemoveContact (string name) //Удаление контакта
        {
            contacts.RemoveAll(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
        public List<Contact> GetContacts () //Получение контактов
        {
            return contacts;
        }
        public List<Contact> SearchContacts (string name) //Поиск контакта
        {
            return contacts.FindAll(c => c.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        public void Register () //Если еще не зарегистрирован контакт, то "true"
        {
            RegisterS = true;
        }
        public void UnRegister () //Если зарегистрирован контакт, то "false"
        {
            RegisterS = false;
        }
    }
}
