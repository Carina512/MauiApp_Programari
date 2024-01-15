    using Vet_Clinic.Models;

namespace Vet_Clinic;

public partial class DoctorEntryPage : ContentPage
{
    public DoctorEntryPage()
    {
        InitializeComponent();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetDoctorsAsync();
    }
    async void OnDoctorAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DoctorPage
        {
            BindingContext = new Doctor()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new DoctorPage
            {
                BindingContext = e.SelectedItem as Doctor
            });
        }
    }
}