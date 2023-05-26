using System.IO;

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
    internal class PhoneBookLoader //Класс
    {
        public static void Load (PhoneBook phoneBook, string fileName) //Загружает текстовый файл в лист бокс
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine( )) != null)
                {
                    string [ ] contactDetails = line.Split(','); 
                    if (contactDetails.Length >= 2)
                    {
                        string name = contactDetails [ 0 ].Trim( );
                        string phone = contactDetails [ 1 ].Trim( );
                        phoneBook.AddContact(new Contact { Name = name, Phone = phone });
                    }
                }
            }
        }
        public static void Save (PhoneBook phoneBook, string fileName) //Сохраняет текстовый файл с новыми контактами
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var contact in phoneBook.GetContacts( ))
                {
                    writer.WriteLine(contact.Name + "," + contact.Phone);
                }
            }
        }
    }
}
