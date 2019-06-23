using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Timers;

namespace Week_03_Client
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
      
            Client client;
            int Itest = 0;


            public MainPage()
            {
                InitializeComponent();
                client = new Client();
                SetTimer();
            }

            private void SetTimer()
            {
                SomeText.Text = "Timer Started";
                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    try
                    {
                        Itest++;
                        test.Text = $"I: {Itest}";
                        client.OpenConnection();
                        Tempature.Text = $"Temp: {client.ReciveData()}";
                        client.CloseConnection();
                        return true; // return true to repeat counting, false to stop timer
                    }
                    catch (Exception e)
                    {
                        SomeText.Text = e.Message;
                        return false;
                    }
                });            
            }
        
    }
}
