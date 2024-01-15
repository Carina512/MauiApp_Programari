using Plugin.LocalNotification;
using Vet_Clinic.Models;

namespace Vet_Clinic;

public partial class ViewAppointments : ContentPage
{
	public ViewAppointments()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetAppointmentsAsync();
    }
    async void OnAppointmentAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateAppointments
        {
            BindingContext = new Appointment()
        });
    }
    async void SaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Appointment)BindingContext;
        

        await App.Database.SaveAppointmentAsync(slist);
        await Navigation.PopAsync();

        if (DateTime.Now.AddDays(1) >= slist.DateTime)
        {
            var request = new NotificationRequest
            {
                Title = "You have an appointment tomorrow! " + slist.ID,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(1)
                }
            };
            await LocalNotificationCenter.Current.Show(request);
        }
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            Appointment selectedAppointment = e.SelectedItem as Appointment;
            await Navigation.PushAsync(new CreateAppointments
            {
                BindingContext = selectedAppointment // Pass the selected appointment to CreateAppointments
            });
        }
    }
}