   M S B A M L   `   `   `  ����E  AImportador, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ImportMtoH
ImportMtoH  5   	       ImportMtoH.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ImportMtoH     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   $	��320��5   	   $	��280��6      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	   ���	#FF3F3F46  MaterialDesignFont#���  5   	    � Title$ IMPORTAR BANCO��5   	   $	��320��5   
   $	��280��6   $	��320��6)   $	��280��69   ���	#DD3F3F46 � WindowStyle$ 
ToolWindow=�6_   $��Center=�6x   $��Center=�6�    � WindowStartupLocation$ CenterScreen=�6�   .��5      � 
�������$��0,0,0,0q�6   .+�5   
   �� $��	0,5,0,250q�6   .+�5      �� $��O que deseja importar?��6   $��Center=�65   $��Center=�6R   $��Arial)�6m   $
��Bold"�6�   $��18(�6�   5      �� 5   
   $��
0,0,136,70q�6   .+�5      �� -   5        $��
checkHiper��5        MaterialDesignCheckBox#��[ 6*    d� 	IsChecked$ FalseY�6Z   $��Hiper Legado��6l   $��10,80,0,-24q�6�   6�   �� 5      -   5        $��checkHiperMini��5      #��[ 6.   $ FalseY�6^   $��	HiperMini��6p   $��10,40,0,-24q�6�   6�   5      �� 5   
   $��
136,0,0,70q�6   .+�5"      �� -   5        $��checkFilial��5"      #��[ 6+   $ FalseY�6[   $��Filial��6m   $��
0,60,0,-24q�6~   $y�Hidden=�6�   �� 5#      -   5        $��checkEntidade��5#      #��[ 6-   $ FalseY�6]   $��Entidade��6o   $��
0,30,0,-24q�6�   $y�Hidden=�6�   �� 5$      -   5        $��	checkProd��5$      #��[ 6)   $ FalseY�6Y   $��Produtos��6k   $��
0,30,0,-24q�6~   $y�Hidden=�6�   �� 5%      -   5        $��checkDoc��5%      #��[ 6(   $ FalseY�6X   $��
Documentos��6j   $��
0,30,0,-24q�6   $y�Hidden=�6�   �� 5'      -   5        $��checkMiniEnt��5'      #��[ 6,   $ FalseY�6\   $��Entidade��6n   $��0,-90,0,-24q�6�   $y�Hidden=�6�   $��24��6�   �� 5(      -   5        $��checkMiniProd��5(      #��[ 6-   $ FalseY�6]   $��Produtos��6o   $��0,-40,0,-24q�6�   $y�Hidden=�6�   $��23��6�   5)      �� 5+   
   $��0,180,140,60q�6   .+�5,      �� -	   5        $��lblNomeServe��5,   b    % !MaterialDesignFloatingHintTextBox#��[ 6   $��5,0,0,0q�6Q   .��6v   )  #MaterialDesignThemes.Wpf.HintAssist   Hint 5-      �� 5.       �� Orientation$ 
Horizontal=�6!   .+�5/      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ Database=�62   �� 50      Nome Servidor52      53      .��54   2   55      56      �� 57   
   $��140,180,0,60q�6   .+�58      �� -
   5        $��lblInstancia��58   b   #��[ 6   $��0,0,5,0q�6Q   .��6v    59      �� 5:      $ 
Horizontal=�6!   .+�5;        $ Database=�62   �� 5<      Nome Instância5>      5?      .��5@   2   5A      5B      �� 5C   
   $��
0,230,0,10q�6   .+�5D      �� -   5        $��	btnImport��5D        MaterialDesignRaisedButton#��[ 6&   3  -MaterialDesignThemes.Wpf.ButtonProgressAssist	   Value$	 -1Q�6Z   
   IsIndicatorVisible
 .    IsIndeterminate . $��IMPORTAR��6  $��
40,10,40,0q�6  ���	#FF1333F7
���   �6T  5E      5F      5G      