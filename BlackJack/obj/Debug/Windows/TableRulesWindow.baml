   M S B A M L   `   `   `  ����D  @BlackJack, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:BlackJack.WindowsBlackJack.Windows  5   	   (    "BlackJack.Windows.TableRulesWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:BlackJack.Windows     5   	     � Title$  TableRulesWindow��5   	   $	��300��6"   $��439.76��6/   .��5	      � .+�5
   
   �� -   5         ��Name$ buttonExport��5
      $��Export��6'   $
��Left=�68   $��
20,228,0,0q�6S   $	��Top=�6g   $��75��6   6�   �� 5   
   -   5        $ buttonImport��5      $��Import��6'   $
��Left=�68   $��110,228,0,0q�6S   $	��Top=�6h   $��75��6�   6�   �� 5   
   -   5        $ buttonOk��5      $��OK��6#   $
��Left=�60   $��310,212,0,0q�6K   $	��Top=�6`   $��78��6x   $��42��6�   6�   �� 5   
   -   5         ��Name$ textBlockDoubleMax��5      $
��Left=�60   $��	20,58,0,0q�6K   $
��Wrap=�6^   $��Double Max:��6r   $	��Top=�6�   �� 5   
   -   5        $ textBlockDoubleMin��5      $
��Left=�60   $��	20,88,0,0q�6K   $
��Wrap=�6^   $��Double Min:��6r   $	��Top=�6�   �� 5   
   -   5        $ textBlockNrOfResplits��5      $
��Left=�63   $��
20,118,0,0q�6N   $
��Wrap=�6b   $#��Nr of resplits (-1 no limit):��6v   $	��Top=�6�   �� 5   
   -   5        $ textBlockNrOfSplitsOnAces��5      $
��Left=�67   $��
20,148,0,0q�6R   $
��Wrap=�6f   $��Nr of splits on Aces:��6z   $	��Top=�6�   �� 5   
   -   5        $" textBlockCardsAfterSplitAces��5      $
��Left=�6:   $��
20,178,0,0q�6U   $
��Wrap=�6i   $��Cards after split Aces:��6}   $	��Top=�6�   �� 5   
   -	   5         ��Name$ textBox5��5      $
��Left=�6$   $��23��6?   $��167,171,0,0q�6K    �� TextWrapping$
 Wrap=�6`   $��1��6t   $	��Top=�6}   $��50��6�   �� 5   
   -
   5        $ textBox4��5      $
��Left=�6$   $��23��6?   $��167,141,0,0q�6K   $
 Wrap=�6`   $��1��6t   $	��Top=�6}   $��50��6�   �� 5   
   -   5        $ textBox3��5      $
��Left=�6$   $��23��6?   $��167,111,0,0q�6K   $
 Wrap=�6`   $��-1��6t   $	��Top=�6~   $��50��6�   �� 5   
   -   5        $ textBox2��5      $
��Left=�6$   $��23��6?   $��
167,81,0,0q�6K   $
 Wrap=�6_   $��9��6s   $	��Top=�6|   $��50��6�   �� 5   
   -   5        $ textBox1��5      $
��Left=�6$   $��23��6?   $��
167,51,0,0q�6K   $
 Wrap=�6_   $��11��6s   $	��Top=�6}   $��50��6�   �� 5   
   -   5         ��Name$ 	checkBox1��5      $��Double on split aces��6&   $
��Left=�6E   $��
275,66,0,0q�6`   $	��Top=�6t   �� 5   
   -   5        $ 	checkBox2��5      $��Double after split��6&   $
��Left=�6C   $��
275,96,0,0q�6^   $	��Top=�6r    d� 	IsChecked$
 TrueY�6�   �� 5   
   -   5        $ 	checkBox3��5      $��Double on soft hand��6&   $
��Left=�6D   $��275,126,0,0q�6_   $	��Top=�6t   �� 5   
   -   5        $ 	checkBox4��5      $��Dealer wins at tie��6&   $
��Left=�6C   $��275,156,0,0q�6^   $	��Top=�6s   5      5      