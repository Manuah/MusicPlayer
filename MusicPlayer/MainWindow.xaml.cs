using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.WebRequestMethods;

namespace MusicPlayer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

  
    public partial class MainWindow : Window
    {
        public static Storyboard sb { get; set; }
        
        public Uri video;
        //Properties.Settings.Default.defaultname = path;

        private MediaPlayer player = new MediaPlayer();
        private int streamHandle;
        private byte[] fftData = new byte[8192];
        string AudioDir;
        DirectoryInfo AudioMedia = new DirectoryInfo("AudioMedia");
        public Uri Text1 { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DisplayFolder("");
            DisplayPlaylist();
            //Audio.Source = new Uri("C:\\Users\\Larisa_Family_PC\\source\\repos\\MusicPlayer\\sample-12s.mp3", UriKind.Relative);
            //MessageBox.Show(AudioMedia.FullName);
            //Text1 = new Uri("C:\\Users\\Larisa_Family_PC\\source\\repos\\MusicPlayer\\sample-12s.mp3", UriKind.Relative);
            this.DataContext = this;

        }

        Uri uri_source;
        string CureentTrack;
        string Playlist = "";

        private void Video_MediaOpened(object sender, RoutedEventArgs e)
        {
           // TimerSlider.Maximum = Audio.NaturalDuration.TimeSpan.TotalSeconds;
        }

        private bool go_player;
        private void TimerSlider_ValueChanged(object sender, RoutedEventArgs e)
        {
            if (!go_player)
                playVideo.Storyboard.Seek(MyWindow, TimeSpan.FromSeconds(TimerSlider.Value), TimeSeekOrigin.BeginTime);
        }

        private void Storyboard_CurrentTimeInvalidated(object sender, EventArgs e)
        {
            // Получаем значение времени для раскадровки
            Clock storyboardClock = (Clock)sender;

            if (storyboardClock.CurrentProgress != null)
            {
                go_player = true;
                TimerSlider.Value = storyboardClock.CurrentTime.Value.TotalSeconds;
                go_player = false;
            }

            label_time.Content = TimeSpan.FromSeconds(Math.Round(TimerSlider.Value));
        }

        private void Audio_MediaOpened(object sender, RoutedEventArgs e)
        {
            TimerSlider.Maximum = Audio.NaturalDuration.TimeSpan.TotalSeconds;
            label_dur.Content = TimeSpan.FromSeconds(Math.Round(Audio.NaturalDuration.TimeSpan.TotalSeconds));
        }


        // play 
        // resume
        // pause

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            Uri video = Audio.Source;
            MediaTimeline mediatimeline = new MediaTimeline(Audio.Source);
            Storyboard.SetTargetName(mediatimeline, Audio.Name);
            //sb.Children.Add(mediatimeline);

            Play.Visibility = Visibility.Hidden;
            Pause.Visibility = Visibility.Visible;
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            Resume.Visibility = Visibility.Visible;
            Pause.Visibility = Visibility.Collapsed;
        }

        private void Resume_Click(object sender, RoutedEventArgs e)
        {
            Resume.Visibility = Visibility.Hidden;
            Pause.Visibility = Visibility.Visible;
        }

        public void DisplayPlaylist()
        {
            string[] files = System.IO.Directory.GetFiles("Playlist");
            for (int x = 0; x < files.Length; x++)
            {
                FileInfo fileInfo = new FileInfo(files[x]);
                if (fileInfo.Exists)
                {
                    listPlayList.Items.Add(System.IO.Path.GetFileNameWithoutExtension(fileInfo.Name));
                }

            }
        }

        public void DisplayFolder(string playlist, List<string> music = null)
        {
            if (playlist == "")
            {
                string[] files = System.IO.Directory.GetFiles("AudioMedia");
                FileInfo fileInfo = new FileInfo(files[0]);
                label_name.Content = fileInfo.Name;

                string s = AudioMedia.FullName + "\\" + (string)fileInfo.Name;
                video = new Uri(s);
                //MessageBox.Show(s);
                ChangeLoopedVideo(video);

                /*string dir = AudioMedia.FullName + "\\" + fileInfo.Name;*/
                //MessageBox.Show(dir);
                //uri_source = new Uri(dir);
                for (int x = 0; x < files.Length; x++)
                {
                    fileInfo = new FileInfo(files[x]);
                    if (fileInfo.Exists)
                    {
                        listFile1.Items.Add(fileInfo.Name);
                    }

                }
            }

            else
            {
                listFile1.Items.Clear();
                for (int x = 0; x < music.Count; x++)
                {
                    string s = AudioMedia.FullName + "\\" + (string)music[x];
                    //MessageBox.Show(s);
                    FileInfo fileInfo2 = new FileInfo(s);
                    if (fileInfo2.Exists)
                    {
                        listFile1.Items.Add(fileInfo2.Name);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка! \nК сожалению, файла " + music[x] + " не существует!");
                    }

                }


              
            }
           
          
        }


        private void listFile1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listFile1.SelectedItem != null)
            {
                CureentTrack = listFile1.SelectedItem.ToString();
                //CureentTrack = listFile1.SelectedItem.ToString();
                //MessageBox.Show(CureentTrack);
                label_name.Content = CureentTrack;
                //string dir = AudioMedia.FullName + "\\" + CureentTrack;
                //MessageBox.Show(dir);
                //uri_source = new Uri(dir);

                string s = AudioMedia.FullName + "\\" + (string)listFile1.SelectedItem;
                video = new Uri(s);
                //MessageBox.Show(s);
                ChangeLoopedVideo(video);


                Play.Visibility = Visibility.Visible;
                Resume.Visibility = Visibility.Hidden;
                Pause.Visibility = Visibility.Hidden;

                TimerSlider.Value = 0;
            }
            
            //label_dur.Content = TimeSpan.FromSeconds(Math.Round(Audio.NaturalDuration.TimeSpan.TotalSeconds));
            //playVideo.Storyboard.Seek(MyWindow, TimeSpan.FromSeconds(TimerSlider.Value), TimeSeekOrigin.Duration);
            //Audio.Source = video;
            //Audio.Play();

        }

        private void ChangeLoopedVideo(Uri url)
        {
            MediaTimeline timeline = new MediaTimeline(url);
            Storyboard.SetTarget(timeline, Audio);
            playVideo.Storyboard.Children.Clear();
            playVideo.Storyboard.Children.Add(timeline);
        }

        private void listPlayList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listPlayList.SelectedItem.ToString().Contains("Главный плейлист"))
            {
                listFile1.Items.Clear();
                Playlist = "";
                DisplayFolder(Playlist);
            }
            else if (listPlayList.SelectedItem.ToString().Contains("Создать плейлист"))
            {
                listFile1.Items.Clear();
                this.Hide();
                CreatePlaylist aw = new CreatePlaylist();
                aw.Show();

            }

            else
            {
                //MessageBox.Show(listPlayList.SelectedItem.ToString());
                Playlist = listPlayList.SelectedItem.ToString();
                List<string> music = new List<string>();

                string dir = "Playlist\\" + Playlist + ".txt";
                StreamReader f = new StreamReader(dir);

                while (!f.EndOfStream)
                {
                    string s = f.ReadLine();
                    music.Add(s);
                    // что-нибудь делаем с прочитанной строкой s
                }
                f.Close();

                DisplayFolder(Playlist, music);
            }
            
        }

    }
}
