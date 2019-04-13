using System;
using System.Linq;
using System.Text.RegularExpressions;
using CSharp_lab2.Exceptions;

namespace CSharp_lab2.Model
{
    internal class Person
    {
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthday;

        private bool _isAdult;
        private string _sunSign;
        private string _chineseSign;
        private bool _isBirthday;

        private static readonly string[] ChineseZodiacSings = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };

        internal string Name
        {
            get => _name;
            set => _name = value;
        }
        internal string Surname
        {
            get => _surname;
            set => _surname = value;
        }
        internal string Email
        {
            get => _email;
            set => _email = value;
        }

        internal DateTime Birthday
        {
            get => _birthday;
            set => _birthday = value;
        }

        public Person(string name, string surname, string email, DateTime birthday)
        {

            _name = name;
            _surname = surname;
            _email = email;
            _birthday = birthday;
            CheckIsNameValid(name, surname);
            CheckIsEmailValid(email);
            CheckIsBirthdayValid(birthday);

        }




        public Person(string name, string surname, string email)
        {

            _name = name;
            _surname = surname;
            _email = email;

        }

        public Person(string name, string surname, DateTime birthday)
        {

            _name = name;
            _surname = surname;
            _birthday = birthday;

        }

        private void CheckIsNameValid(string name, string surname)
        {
            if (!name.All(char.IsLetter) || !surname.All(char.IsLetter))
            {
                throw new WrongNameException(name + " is bad name");
            }
        }


        private void CheckIsEmailValid(string email)
        {
            if (!IsValidEmailAddress(email))
            {
                throw new WrongEmailPatternException(email + " is bad");
            }
        }
        public static bool IsValidEmailAddress(string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }

        private void CheckIsBirthdayValid(DateTime birthday)
        {
            // date.Year > 1890 && date.CompareTo(DateTime.Today) <= 0 ;
            if (birthday.Year < 1890)
            {
                throw new PastDateOfBirthdayException(birthday + " is to low for birthday");
            }

            if (birthday.CompareTo(DateTime.Today) > 0)
            {
                throw new FutureDateOfBirthdayException(birthday + " is in future so in can`t be your birthday");
            }
        }

        internal bool IsAdult
        {
            get
            {
                _isAdult = IsPersonAdult();
                return _isAdult;
            }
        }

        private bool IsPersonAdult()
        {
            var age = DateTime.Today.Year - _birthday.Year;
            if (DateTime.Today < _birthday.AddYears(age)) age--;
            return age >= 18;
        }

        internal string SunSign
        {
            get
            {
                if (_sunSign != null)
                    return _sunSign;
                _sunSign = GetSunSign();
                return _sunSign;
            }
        }

        private string GetSunSign()
        {
            switch (_birthday.Month)
            {
                case 12 when (_birthday.Day >= 22 && _birthday.Day <= 31):
                case 1 when (_birthday.Day >= 1 && _birthday.Day <= 19):
                    return "Capricorn";
                case 1 when (_birthday.Day >= 20 && _birthday.Day <= 31):
                case 2 when (_birthday.Day >= 1 && _birthday.Day <= 17):
                    return ("Aquarius");
                case 2 when (_birthday.Day >= 18 && _birthday.Day <= 29):
                case 3 when (_birthday.Day >= 1 && _birthday.Day <= 19):
                    return ("Pisces");
                case 3 when (_birthday.Day >= 20 && _birthday.Day <= 31):
                case 4 when (_birthday.Day >= 1 && _birthday.Day <= 19):
                    return ("Aries");
                case 4 when (_birthday.Day >= 20 && _birthday.Day <= 30):
                case 5 when (_birthday.Day >= 1 && _birthday.Day <= 20):
                    return ("Taurus");
                case 5 when (_birthday.Day >= 21 && _birthday.Day <= 31):
                case 6 when (_birthday.Day >= 1 && _birthday.Day <= 20):
                    return ("Gemini");
                case 6 when (_birthday.Day >= 21 && _birthday.Day <= 30):
                case 7 when (_birthday.Day >= 1 && _birthday.Day <= 22):
                    return ("Cancer");
                case 7 when (_birthday.Day >= 23 && _birthday.Day <= 31):
                case 8 when (_birthday.Day >= 1 && _birthday.Day <= 22):
                    return ("Leo");
                case 8 when (_birthday.Day >= 23 && _birthday.Day <= 31):
                case 9 when (_birthday.Day >= 1 && _birthday.Day <= 22):
                    return ("Virgo");
                case 9 when (_birthday.Day >= 23 && _birthday.Day <= 30):
                case 10 when (_birthday.Day >= 1 && _birthday.Day <= 22):
                    return ("Libra");
                case 10 when (_birthday.Day >= 23 && _birthday.Day <= 31):
                case 11 when (_birthday.Day >= 1 && _birthday.Day <= 21):
                    return ("Scorpio");
                case 11 when (_birthday.Day >= 22 && _birthday.Day <= 30):
                case 12 when (_birthday.Day >= 1 && _birthday.Day <= 21):
                    return ("Sagittarius");
                default: return "Wrong";
            }
        }

        internal string ChineseSign
        {
            get
            {
                if (_chineseSign != null)
                    return _chineseSign;
                _chineseSign = GetChineseSign();
                return _chineseSign;
            }
        }

        private string GetChineseSign()
        {
            return ChineseZodiacSings[(_birthday.Year - 4) % 12];
        }

        internal bool IsBirthday
        {
            get
            {
                _isBirthday = IsPersonBirthday();
                return _isBirthday;
            }
        }

        private bool IsPersonBirthday()
        {
            return _birthday.Month == DateTime.Today.Month && _birthday.Day == DateTime.Today.Day;
        }

        public override string ToString()
        {
            return "Name: " + _name + "\n" +
                   "Surname: " + _surname + "\n" +
                   "Email: " + _email + "\n" +
                   "Birthday: " + Birthday.ToShortDateString() + "\n" +
                   "Sun sign: " + SunSign + "\n" +
                   "Chinese sign: " + ChineseSign + "\n" +
                   "Is adult? : " + IsAdult + "\n" +
                   "Is birthday?: " + IsBirthday;
        }
    }
}
