   M S B A M L   `   `   `  ���� E  AImportador, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ImportMtoH
ImportMtoH      ImportMtoH.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:ImportMtoH     V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  $	��320��$	��280��   MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=����	#FF3F3F46  MaterialDesignFont#���   � Title$ IMPORTAR BANCO��$	��320��$	��280��$	��320��$	��280�����	#DD3F3F46 � WindowStyle$ 
ToolWindow=�$��Center=�$��Center=� � WindowStartupLocation$ CenterScreen=�.��� 
�������$��0,0,0,0q�.+��� $��	0,5,0,250q�.+��� $��O que deseja importar?��$��Center=�$��Center=�$��Arial)�$
��Bold"�$��18(��� $��
0,0,136,70q�.+��� -   $��
checkHiper��  MaterialDesignCheckBox#��[  d� 	IsChecked$ FalseY�$��Hiper Legado��$��10,80,0,-24q��� -   $��checkHiperMini��#��[ $ FalseY�$��	HiperMini��$��10,40,0,-24q��� $��
136,0,0,70q�.+��� -   $��checkFilial��#��[ $ FalseY�$��Filial��$��
0,60,0,-24q�$y�Hidden=��� -   $��checkEntidade��#��[ $ FalseY�$��Entidade��$��
0,30,0,-24q�$y�Hidden=��� -   $��	checkProd��#��[ $ FalseY�$��Produtos��$��
0,30,0,-24q�$y�Hidden=��� -   $��checkDoc��#��[ $ FalseY�$��
Documentos��$��
0,30,0,-24q�$y�Hidden=��� -   $��checkMiniEnt��#��[ $ FalseY�$��Entidade��$��0,-90,0,-24q�$y�Hidden=�$��24���� -   $��checkMiniProd��#��[ $ FalseY�$��Produtos��$��0,-40,0,-24q�$y�Hidden=�$��23���� $��0,180,140,60q�.+��� -	   $��lblNomeServe�� % !MaterialDesignFloatingHintTextBox#��[ $��5,0,0,0q�.��)  #MaterialDesignThemes.Wpf.HintAssist   Hint ��  �� Orientation$ 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ Database=��� Nome Servidor.���� $��140,180,0,60q�.+��� -
   $��lblInstancia��#��[ $��0,0,5,0q�.�� �� $ 
Horizontal=�.+�  $ Database=��� Nome Instância.���� $��
0,230,0,10q�.+��� -   $��	btnImport��  MaterialDesignRaisedButton#��[ 3  -MaterialDesignThemes.Wpf.ButtonProgressAssist	   Value$	 -1Q�
   IsIndicatorVisible
 .    IsIndeterminate . $��IMPORTAR��$��
40,10,40,0q����	#FF1333F7
���   �