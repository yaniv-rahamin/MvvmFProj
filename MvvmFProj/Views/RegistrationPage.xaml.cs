using MvvmFProj.ViewModels;
 

namespace MvvmFProj.Views;

public partial class RegistrationPage : ContentPage
{
   

    public RegistrationPage()
    {
        InitializeComponent();
        BindingContext = new AddNewUserVm();

    }

  
}