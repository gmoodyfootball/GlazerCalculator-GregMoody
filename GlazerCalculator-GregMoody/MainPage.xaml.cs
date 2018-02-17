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

        private void textBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

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
                width = 0;
                speakToMe("You didn't enter a correct width. What are you, conscious of your fat?");
            }
            heightString = heightTextBox.Text;
            try
            {
                height = double.Parse(heightString);
            }
            catch
            {
                height = 0;
                if (width != 0)
                {
                    speakToMe("You didn't enter a correct height. What are you, a midget?");
                }
            }
            woodLength = 2 * (width + height) * 3.25;
            glassArea = 2 * (width * height);

            // Console.WriteLine("The length of the wood is " +
            // woodLength + " feet");
            // Console.WriteLine("The area of the glass is " +
            // glassArea + " square metres")
            

        }
        private async void speakToMe(string creepyVoice)
        {
            MediaElement mediaElement = new MediaElement();
            var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
            Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync(creepyVoice);
            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();
        }
        private void quantitySlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            quantityLabel.Text = quantitySlider.Value.ToString();
        }
    }
}
