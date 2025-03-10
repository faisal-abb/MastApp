using System;
using System.Runtime.InteropServices;
using Microsoft.Maui.Controls;

namespace MastApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //private async void onShowMessageClicked(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string message = NativeMethods.printHello(); // FIX: No need to use `IntPtr`
        //        Console.WriteLine(message);
        //        await DisplayAlert("Native Output", message, "OK"); // Show output in alert
        //    }
        //    catch (Exception ex)
        //    {
        //        await DisplayAlert("Error", $"Failed to execute native method: {ex.Message}", "OK");
        //    }
        //}

        private void OnAddClicked(object sender, EventArgs e)
        {
            string dllPath = NativeMethods.GetLoadedDllPath();
            DllPathLabel.Text = $"DLL Path: {dllPath}";

            if (TryGetInputs(out double a, out double b))
            {
                try
                {
                    double result = NativeMethods.AddWrapper(a, b);
                    ResultLabel.Text = $"Result: {result}";
                    ResultLabel.Text = $"Value of a = {a}, value of b = {b} : Result = {result}";
                }
                catch (Exception ex)
                {
                    ResultLabel.Text = "Error: " + ex.Message;
                }
            }
        }


        private void OnSubtractClicked(object sender, EventArgs e)
        {
            if (TryGetInputs(out double a, out double b))
            {
                try
                {
                    double result = NativeMethods.SubtractWrapper(a, b);
                    Console.WriteLine("Value of a is " + a);
                    Console.WriteLine("Value of b is " + b);
                    ResultLabel.Text = $"Result: {result}";
                    Console.WriteLine("Resule is " + result);
                }
                catch (Exception ex)
                {
                    ResultLabel.Text = "Error: " + ex.Message;
                }
            }
        }

        private void OnMultiplyClicked(object sender, EventArgs e)
        {
            if (TryGetInputs(out double a, out double b))
            {
                try
                {
                    double result = NativeMethods.MultiplyWrapper(a, b);
                    Console.WriteLine("Value of a is " + a);
                    Console.WriteLine("Value of b is " + b);
                    ResultLabel.Text = $"Result: {result}";
                    Console.WriteLine("Value of result is " + result);
                }
                catch (Exception ex)
                {
                    ResultLabel.Text = "Error: " + ex.Message;
                }
            }
        }

        private void OnDivideClicked(object sender, EventArgs e)
        {
            if (TryGetInputs(out double a, out double b))
            {
                if (b == 0)
                {
                    ResultLabel.Text = "Error: Division by zero!";
                    return;
                }
                try
                {
                    double result = NativeMethods.DivideWrapper(a, b);
                    Console.WriteLine("Value of a is " + a);
                    Console.WriteLine("Value of b is "+b);
                    ResultLabel.Text = $"Value of a = {a}, value of b = {b} : Result = {result}";
                }
                catch (Exception ex)
                {
                    ResultLabel.Text = "Error: " + ex.Message;
                }
            }
        }

        private bool TryGetInputs(out double a, out double b)
        {
            bool validA = double.TryParse(EntryA.Text, out a);
            bool validB = double.TryParse(EntryB.Text, out b);

            if (!validA || !validB)
            {
                ResultLabel.Text = "Invalid input";
                return false;
            }
            return true;
        }
    }
}
