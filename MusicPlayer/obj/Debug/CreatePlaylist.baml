   M S B A M L   `   `   `  ����F  BMusicPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MusicPlayerMusicPlayer  5   	        MusicPlayer.CreatePlaylist   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:MusicPlayer     5   	     � 
ResizeMode$  NoResize=�5       � Title$ CreatePlaylist��5   	   $	��450��6    $	��800��6-   ��5
      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ Black��6   � 5      $ White��6    � Offset$ 1Q�6)   5       � 	Resources 5         	FirstCell �� Orientation d� 	IsChecked	 �� Path
 �� RelativeSource �� AncestorType��%�   &	        �� 5   
   .R�5      �� $ 
Horizontal=�6   .+�5      ��  6   �� $	 
IsSelected�
 �� *FindAncestor+" ��5      5      5      .��5      � $��0,0,0,-6q�6    � ColumnDefinitions 5   
   �� 5      $
��152* �6   �� 5      $	��21* �6   ��5   
   �� 5      $ 0.5,1&�6"   $ 0.5,0&�63   .��5       � $ 	#FFFFD4F9��6   $ 0Q�61   � 5!      $ 	#FF171016��6   $ 0.821Q�61   5"       � RowDefinitions 5$   
   �� 5%      $��213.04 �6   6.   �� 5&      $
��auto �6   $	��137��6*   6<   �� 5'      $
��auto �6   $��39.04��6*   6>   .+�5+   
   �� -   5         ��Name$ 	listFile1��5+      $��16(�6&   $��1,1,1,1q�64   $��95,17,317,23q�6N   ���	#FF5F151C$��Center=�6|   $��2��6�    5,       �� 
TargetType �� Property �� Value��%_   '��       �� 5-      " ��6   .�5.      ��  �@��CornerRadius$ 10��65   5/      50      ��51      �� 52      $ 0.5,1&�6&   $ 0.5,0&�67   .��53      � $ Transparent��6#   $ 0.041Q�67   � 54      $ 	#FFD29BD8��6#   $ 0.923Q�65   55      ��57      �� 58      $ 0.5,1&�6&   $ 0.5,0&�67   .��59      � $ Black��6#   � 5:      $ 	#FFCE3A3A��6#   $ 1Q�65   5;      5?      �� 5A   
   -   5         ��Name$ 
label_name��5A      $)��#Создание плейлиста��6$   $
��Left=�6A   $��2��6\   $��Center=�6i   
�������$
��Bold"�6�   $��20(�6�   $	��442��6�   $��37��6�   $��2��6�   $��	288,0,0,0q�6�   �� 5B   
   -   5         ��Name$ listPlayList��5B      $��10q�6(   $��16(�65   $��1,1,1,1q�6C   $��451,17,10,106q�6]   ���	#FF5F151C$��Center=�6�    5C      ��%_   '��       �� 5D      " ��6   .�5E      ��  �@��CornerRadius$ 10��65   5F      5G      .@�5H      �� -   5         ��Name$ 
txt_b_name��5H      $	��164��6*   $��25��66   $)��#Название плейлиста��6B   $��14(�6\   $��Center=�6j   .��6�   ��5I      �� 5J      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5K      � $ Black��6'   � 5L      $ 	#FFCE3A3A��6'   $ 1Q�69   5M      .��5N   &   5O      �� 5P      $%��Создать плейлист��6   ��5Q      �� 5R      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5S      � $ Black��6'   � 5T      $ 	#FFCE3A3A��6'   $ 1Q�69   5U      5W      ��5X      �� 5Y      $ 0.5,1&�6&   $ 0.5,0&�67   .��5Z      � $ Transparent��6#   $ 0.041Q�67   � 5[      $ 	#FFD29BD8��6#   $ 0.923Q�65   5\      ��5^      �� 5_      $ 0.5,1&�6&   $ 0.5,0&�67   .��5`      � $ Black��6#   � 5a      $ 	#FFCE3A3A��6#   $ 1Q�65   5b      5d      �� 5e   
   -   5        $ listPlayList_music��5e      $��10q�6.   $��16(�6;   $��1,1,1,1q�6I   $��451,141,10,23q�6c   ���	#FF5F151C$��Center=�6�   $��2��6�    5f      ��%_   '��       �� 5g      " ��6   .�5h      ��  �@��CornerRadius$ 10��65   5i      5j      ��5k      �� 5l      $ 0.5,1&�6&   $ 0.5,0&�67   .��5m      � $ 	#FFC1C1C1��6#   $ 0.959Q�65   � 5n      $ 	#FFD29BD8��6#   $ 0.077Q�65   5o      ��5q      �� 5r      $ 0.5,1&�6&   $ 0.5,0&�67   .��5s      � $ Black��6#   � 5t      $ 	#FFCE3A3A��6#   $ 1Q�65   5u      5y      �� 5z   
   -   5        $
��Left=�5z      $��53��6+   $��	21,17,0,0q�67   $	��Top=�6J   $��49��6b   $#��Resources\bak_arrow_black.png��6m   6�   �� 5|   
   $	��100��6   $	��100��6   $��336,57,267,56q�6)   5~      5      