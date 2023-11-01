using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace MusicPlayer
{
    /// <summary>
    /// Логика взаимодействия для CreatePlaylist.xaml
    /// </summary>
    public partial class CreatePlaylist : Window
    {
        public CreatePlaylist()
        {
            InitializeComponent();
            DisplayFolder();
            
            
        }

        List<string> music = new List<string>();
        public void DisplayFolder()
        {
                string[] files = System.IO.Directory.GetFiles("AudioMedia");

            //label_name.Content = fileInfo.Name;

            //string s = AudioMedia.FullName + "\\" + (string)fileInfo.Name;
            //video = new Uri(s);
            ////MessageBox.Show(s);
            //ChangeLoopedVideo(video);

            /*string dir = AudioMedia.FullName + "\\" + fileInfo.Name;*/
            //MessageBox.Show(dir);
            //uri_source = new Uri(dir);
            
            for (int x = 0; x < files.Length; x++)
                {
                    FileInfo fileInfo = new FileInfo(files[x]);
                    fileInfo = new FileInfo(files[x]);
                    if (fileInfo.Exists)
                    {
                        listFile1.Items.Add(fileInfo.Name);
                    }

            }


            //listView1.Items[0].BackColor = Color.Red;

        }

        public void DisplayMusic()
        {

            listPlayList_music.Items.Clear();
            for (int x = 0; x < music.Count; x++)
            {
                listPlayList_music.Items.Add(music[x]);
            }

        }

        private void listFile1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBoxResult result;
            string s = listFile1.SelectedItem.ToString();
            //MessageBox.Show(s);
            result = MessageBox.Show("Добавить песню " + listFile1.SelectedItem.ToString() + "в плейлист?", "Добавить", 
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
            if (result == MessageBoxResult.Yes)
            {
                int copy = 0;
                for (int x = 0; x < listPlayList_music.Items.Count; x++)
                {
                    if (listPlayList_music.Items[x].ToString() == s)
                    {
                        copy++;
                    }
                }
                if (copy == 0)
                {
                    music.Add(s);
                    DisplayMusic();
                }
            }
          
            //int n = Convert.ToInt32(listFile1.SelectedIndex);

            //int n = Convert.ToInt32(listFile1.SelectedIndex);
            //listFile1.Items[n].BackColor = Color.Red;
            ////listView1.SelectedItem.BackColor = Color.Red;
        }

        bool change = true;
        private void listPlayList_music_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (change)
            {
                int n = listPlayList_music.SelectedIndex;
                MessageBox.Show(n.ToString());
                //MessageBox.Show(n.ToString());

                music.RemoveAt(n);
                //MessageBox.Show(change.ToString());
                change = false;
                DisplayMusic();

            }
            else
            {
                //MessageBox.Show(change.ToString());
                change = true;
            }
            

        }

        private void listPlayList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listPlayList.SelectedItem.ToString().Contains("Создать плейлист"))
            {
                string path = "Playlist\\" + txt_b_name.Text + ".txt";

                FileInfo fileInfo = new FileInfo(path);
                if (fileInfo.Exists)
                {
                    var result = MessageBox.Show("Плейлист с названием " + txt_b_name.Text + " уже существует. Перезаписать?", "Ошибка",
                MessageBoxButton.YesNo, MessageBoxImage.Error, MessageBoxResult.Yes);
                    if (result == MessageBoxResult.No)
                    {
                        return;
                    }
                }

                try
                {
                    using (StreamWriter writer = new StreamWriter(path, false))
                    {
                        for (int x = 0; x < music.Count; x++)
                        {
                            writer.WriteLineAsync(music[x]);
                            MessageBox.Show(music[x]);
                        }
                    }
                    MessageBox.Show("Плейлист '" + txt_b_name.Text + "' создан!");
                    this.Close();
                    MainWindow aw = new MainWindow();
                    aw.Show();

                }
                catch
                {
                    MessageBox.Show("Не удалось записать плейлист");
                }
               



            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            MainWindow aw = new MainWindow();
            aw.Show();
        }
    }


    }

