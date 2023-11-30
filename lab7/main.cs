using System;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace WebApplication
{
    public partial class WebForm1 : Page
    {
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string surname = SurnameTextBox.Text;
            string name = NameTextBox.Text;
            string email = EmailTextBox.Text;

            // Визначення довжини прізвища та імені
            int surnameLength = surname.Length;
            int nameLength = name.Length;

            // Заміна літер
            string modifiedSurname = surname.Replace('а', 'о');

            // Перевірка email
            string emailPattern = @"^\S+@\S+\.\S+$";
            bool isEmail = Regex.IsMatch(email, emailPattern);

            // Виведення результату
            Label1.Text = $"Довжина прізвища: {surnameLength}, Довжина імені: {nameLength}, Змінене прізвище: {modifiedSurname}, Чи є email: {isEmail}";
        }
    }
}

