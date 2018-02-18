using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GlazerCalculator_GregMoody
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }


        //Visual studio made this function on accident, and it flips out if I try to delete it. So here it stays :)
        private void textBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {
            //Hi everyone! I'm an unused function!!
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            
            double width, height, woodLength, glassArea;
            string widthString, heightString;
            widthString = widthTextBox.Text;
            try
            {
                width = double.Parse(widthString);
            } catch
            {
                //This should never be called, unless they didn't enter a value to begin with
                widthTextBox.Text = "0";
                width = 0;
            }
            heightString = heightTextBox.Text;
            try
            {
                height = double.Parse(heightString);
            }
            catch
            {
                //This should never be called, unless they didn't enter a value in begin with
                heightTextBox.Text = "0";
                height = 0;
            }
            woodLength = 2 * (width + height) * 3.25;
            glassArea = 2 * (width * height);

            DateTime dateOrdered = DateTime.Now;

            DisplayTotalsDialog(width, height, glassArea, woodLength, dateOrdered);

            if (width ==0 || height == 0)
            {
                speakToMe("Well, this isn't going to make a nice Window. You didn't specify width or height! So, I'm going to assume you didn't really want a window");
            }
            else
            {
                speakToMe("Here are your totals. Aren't they nice?");
            }

        }

        //This will pop up a dialog to show the user's output
        private async void DisplayTotalsDialog(double width, double height, double glassArea, double woodLength, DateTime dateOrdered)
        {
            ContentDialog displayTotalsDialog = new ContentDialog
            {
                Title = "Your Totals",
                Content = "Width: " + width + "\n"
                + "Height: " + height + "\n"
                + "Glass Area: " + glassArea + "\n"
                + "Wood Length: " + woodLength + "\n"
                + "Date Ordered: " + dateOrdered,
                CloseButtonText = "Neat!"
            };

            ContentDialogResult result = await displayTotalsDialog.ShowAsync();
        }


        //This is just for fun to let the program make sassy remarks to the user
        //This is from the "Hello World" example on Microsoft's website. I just modified it to accept a string input
        private async void speakToMe(string creepyVoice)
        {
            MediaElement mediaElement = new MediaElement();
            var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
            Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync(creepyVoice);
            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();
        }

        //Just to update the quantity label
        private void quantitySlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            quantityLabel.Text = quantitySlider.Value.ToString();
        }

        private void widthTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Check each of the characters in the string in the text box, and make sure that they are all numbers
            //If it's not, delete it, and tell them why
            string tString = widthTextBox.Text;
            if (tString.Trim() == "") return;
            for (int i = 0; i < tString.Length; i++)
            {
                if (!char.IsNumber(tString[i]))
                {
                    speakToMe("Please enter a valid number for the width. It's not that hard, I promise");
                    widthTextBox.Text = "";
                    return;
                }

            }
        }

        private void heightTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Check each of the characters in the string in the text box, and make sure that they are all numbers
            //If it's not, delete it, and tell them why
            string tString = heightTextBox.Text;
            if (tString.Trim() == "") return;
            for (int i = 0; i < tString.Length; i++)
            {
                if (!char.IsNumber(tString[i]))
                {
                    speakToMe("Please enter a valid number for the height");
                    heightTextBox.Text = "";
                    return;
                }

            }
        }
    }
}
