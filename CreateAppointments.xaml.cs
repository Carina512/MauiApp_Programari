using Vet_Clinic.Models;

namespace Vet_Clinic;

public partial class CreateAppointments : ContentPage
{
	public CreateAppointments()
	{
		InitializeComponent();
        LoadAppointmentsAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var appointment = (Appointment)BindingContext;

       

        var doctors = await App.Database.GetDoctorsAsync();
        DoctorPicker.ItemsSource = (System.Collections.IList)doctors;
        DoctorPicker.ItemDisplayBinding = new Binding("FullName");
        var selectedDoctor = doctors.FirstOrDefault(d => d.ID == appointment.DoctorID);
        DoctorPicker.SelectedItem = selectedDoctor;
    }
    private async void LoadAppointmentsAsync()
    {
        

        var doctors = await App.Database.GetDoctorsAsync();
        DoctorPicker.ItemsSource = (System.Collections.IList)doctors;
        DoctorPicker.ItemDisplayBinding = new Binding("FullName");
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var appointment = (Appointment)BindingContext;

      
        Doctor selectedDoctor = (DoctorPicker.SelectedItem as Doctor);
        appointment.DoctorID = selectedDoctor.ID;

        DateTime selectedDate = datePicker.Date;
        TimeSpan selectedTime = timePicker.Time;
        appointment.DateTime = selectedDate.Date + selectedTime;

        await App.Database.SaveAppointmentAsync(appointment);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var appointment = (Appointment)BindingContext;
        await App.Database.DeleteAppointmentAsync(appointment);
        await Navigation.PopAsync();
    }
   
}   