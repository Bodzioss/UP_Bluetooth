   M S B A M L   `   `   `  ����F  BBluetooth_m, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Bluetooth_mBluetooth_m  5   	       Bluetooth_m.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Bluetooth_m     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ 	filesList��5
      $��182,217,281,87q�6&    �� View 5      �� 5      .P�5      �� 5      5      �� 5   
   -   5         ��Name$ 
titleLabel��5      $��Lab 6 Bluetooth��6$   $��Center=�6>   $��0,57,0,0q�6[   $	��Top=�6m   $��22(�6�   �� 5   
   -   5         ��Name$ 
quitButton��5      $��Zakończ��6%   $
��Left=�67   $��
70,334,0,0q�6R   $	��Top=�6f   $��32��6~   $��82��6�   �� 5   
   -   5        $ getFileButton��5      $��Dodaj do listy��6(   $
��Left=�6A   $��
70,217,0,0q�6\   $	��Top=�6p   $��32��6�   $��82��6�   6�   �� 5   
   -   5        $ sendFileButton��5      $��Wyslij plik��6)   $
��Left=�6?   $��304,124,0,0q�6Z   $	��Top=�6o   $��32��6�   $��82��6�   6�   �� 5   
   -   5        $ findDeviceButton��5      $��Znajdź urzadzenia��6+   $
��Left=�6G   $��
141,64,0,0q�6b   $	��Top=�6v   $��32��6�   $��82��6�   6�   �� 5   
   -   5        $ findAdapterButton��5      $��Znajdź adaptery��6,   $
��Left=�6F   $��	29,64,0,0q�6a   $	��Top=�6t   $��82��6�   $��32��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ deviceDataGrid��5      $
��Left=�6+   $	��228��6F   $��	534,0,0,0q�6S   $��Center=�6f   $	��202��6�      AutoGenerateColumns$ False��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Something��69   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6%   �� 69   5      �� 5   
   -	   5        
 ��Name$
 deviceComboBox��5      $
��Left=�6+   $��546,356,0,0q�6F   $	��Top=�6[   $	��120��6s   �� 5   
   -
   5        $ connectButton��5      $��Połącz��6(   $
��Left=�69   $��694,351,0,0q�6T   $	��Top=�6i   $��96��6�   $��31��6�   6�   �� 5   
   -   5        $
 fileComboBox��5      $
��Left=�6)   $��200,175,0,0q�6D   $	��Top=�6Y   $	��120��6q   �� 5    
   -   5        $
 recieverComboBox��5       $
��Left=�6-   $��376,175,0,0q�6H   $	��Top=�6]   $	��120��6u   6�   �� 5!   
   -   5        $ deleteButton��5!      $��Usun z listy��6'   $
��Left=�6>   $��
71,262,0,0q�6Y   $	��Top=�6m   $��81��6�   $��20��6�   �� 5"   
   -   5        $ sendAllButton��5"      $��Wyślij wszystkie��6(   $
��Left=�6C   $��
70,296,0,0q�6^   $	��Top=�6r   $��81��6�   6�   � 5#   
   -   5         �Name$ filesSendProgressBar��5#      $
��Left=�64   $��22��6O   $��182,356,0,0q�6[   $	��Top=�6p   $	��337��6�   5%      5&      