using Vet_Clinic.Models;

namespace Vet_Clinic;

public partial class DoctorPage : ContentPage
{
    public DoctorPage()
    {
        InitializeComponent();
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Doctor)BindingContext;
        await App.Database.SaveDoctorAsync(slist);
        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Doctor)BindingContext;
        await App.Database.DeleteDoctorAsync(slist);
        await Navigation.PopAsync();
    }
}