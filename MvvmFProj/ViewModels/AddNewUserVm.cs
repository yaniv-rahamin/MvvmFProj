 
using MvvmFProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;


namespace MvvmFProj.ViewModels
{
    internal class AddNewUserVm :ObservableObject
    {
        private string? name;
        private string? password;
        private string? age;
        private DateTime birthDate;
        private string? errorNameMessage;
        private string? errorPasswordMessage;
        private string? errorAgeMessage;
        private int heightFrameName;
        private int heightFramePassword;
        

        public AddNewUserVm()
        {
            BirthDate = new DateTime(DateTime.Now.Year - 18, DateTime.Now.Month, DateTime.Now.Day);
            HeightFrameName = 100;
            HeightFramePassword = 100;
            AddUserCommand = new Command<string>(AddNewUser);
            
        }

        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                    HandleErrorName();
                }
            }
        }

      

        public string Password
        {
            get => password;
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged(nameof(Password));
                    HandleErrorPassword();
                }
            }

        }

        public DateTime BirthDate
        {
            get => birthDate;
            set
            {
                if (birthDate != value)
                {
                    birthDate = value;
                    OnPropertyChanged(nameof(BirthDate));
                    Age = Agecalculation();
                    OnPropertyChanged(nameof(Age));
                    HandleErrorAge();
                }
            }
        }

        private string Agecalculation()
        {
            int age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now.Month < birthDate.Month ||
                (DateTime.Now.Month == birthDate.Month && DateTime.Now.Day < birthDate.Day))
            {
                age--;
            }
            return $"{age}";    
        }

        public string Age
        {
            get => age;
            set
            {
                age = value;

            }
        }

        public string ErrorNameMessage 
        {
            get => errorNameMessage;
            set
            {
                if (errorNameMessage != value)
                {
                    errorNameMessage = value;
                    OnPropertyChanged(nameof(ErrorNameMessage));
                }
                
            }  
        }
        public bool HasErrorBtn
        {
            get
            {
                return !HasErrorAge && !HasErrorName && !HasErrorPassword;
            }

        }

        public bool HasErrorName
        {
            get
            {
                return string.IsNullOrEmpty(Name) || !IsValidName() ;
            }

        }
        public bool HasErrorPassword
        {
            get
            {
                return string.IsNullOrEmpty(Password) || !IsValidPassword();
            }

        }
        public bool HasErrorAge
        {
            get
            {
                return !IsVaildAge();
            }

        }

        public int HeightFrameName
        {
            get => heightFrameName;
            set { heightFrameName = value; OnPropertyChanged(nameof(HeightFrameName)); }
        }

        public int HeightFramePassword
        {
            get => heightFramePassword;
            set { heightFramePassword = value; OnPropertyChanged(nameof(HeightFramePassword)); }
        }

        public string? ErrorPasswordMessage
        {
            get => errorPasswordMessage;
            set { errorPasswordMessage = value; OnPropertyChanged(nameof(ErrorPasswordMessage)); }
        }

        public string? ErrorAgeMessage
        {
            get => errorAgeMessage;
            set { errorAgeMessage = value; OnPropertyChanged(nameof(ErrorAgeMessage)); }
        }

        private void HandleErrorAge()
        {
            if (!IsVaildAge())
            {
                ErrorAgeMessage = "Age must be 18 or older";
               
            }

            else
            {
                ErrorAgeMessage = string.Empty;
               
            }
            OnPropertyChanged(nameof(HasErrorAge));
            OnPropertyChanged(nameof(HasErrorBtn));
        }


        private void HandleErrorPassword()
        {
            if (!IsValidPassword())
            {
                ErrorPasswordMessage = "password contain at least one letter, one number, and a minimum of 6 characters";
                HeightFramePassword = 110;
            }

            else
            {
                ErrorPasswordMessage = string.Empty;
                HeightFramePassword = 100;
            }
            OnPropertyChanged(nameof(HasErrorPassword));
            OnPropertyChanged(nameof(HasErrorBtn));
        }
        private void HandleErrorName()
        {
            if (!IsValidName())
            {
                ErrorNameMessage = "name Start with a letter and Contains only letters and Is more than 2 characters long";
                HeightFrameName = 110;
            }

            else
            {
                ErrorNameMessage = string.Empty;
                HeightFrameName = 100;
            }
            OnPropertyChanged(nameof(HasErrorName));    
            OnPropertyChanged(nameof(HasErrorBtn));
        }
        private bool IsValidName()
        {
            // Regular expression to check if the name:
            // 1. Starts with a letter.
            // 2. Contains only letters.
            // 3. Is more than 2 characters long
            Regex reg = new Regex(@"^[a-zA-Z]{3,}$");
            return reg.IsMatch(Name);
            
        }
        private bool IsVaildAge()
        {          
            int age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now.Month < birthDate.Month ||
                (DateTime.Now.Month == birthDate.Month && DateTime.Now.Day < birthDate.Day))
            {
                age--;
            }

            
            return age >= 18;
        }
        private bool IsValidPassword()
        {
            // Regex pattern: at least one letter, one number, and a minimum of 6 characters
            Regex reg = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$");
            return reg.IsMatch(Password);
        }
        public ICommand AddUserCommand { get; protected set; }

        public void AddNewUser(string name)
        {
            if (name == "registration")
            {
                if (!HasErrorAge && !HasErrorName && !HasErrorPassword)
                {
                    ErrorAgeMessage = "successfully";
                    
                }                  
                else
                    ErrorAgeMessage = string.Empty;
            }
        }

    }
}
