   M S B A M L   `   `   `  ����A  =KVKApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:KVKApp.ViewsKVKApp.Views  5   	       KVKApp.Views.MainView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:KVKApp.Views     5   	     � Title$  MainView��5   	   $	��720��6   $
��1080��6'   .��5	      �  � RowDefinitions 5
   
   �� 5      $��2* �6   �� 5      $��4* �6   �� 5      $��4* �6   .+�5   
   � $��0��6   
�������.+�5      �� $��Center=�6   $��Center=�61   $��32(�6L   .��6Z   KVK API HORECA6j   5      �� 5   
   $��1��6   $��Center=�6"   $��Center=�6?   .+�5      �� $��Data Ophalen��6   
�������$	��144��6?   $��48��6K   $
��0,12q�6W   ��6e   �� *
ApiCommand+6�   �� 5      $��	Exporteer��6   
�������$	��144��6<   $��48��6H   $
��0,12q�6T   {�6b   �� *ButtonPrintEnabled+��6�   �� *PrintCommand+6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgrid��5      $��2��6"      AutoGenerateColumns$ False��6Q   ��6/   �� *	Companies+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
KvK Nummer��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *	KvkNumber+  5      $ Business Naam��6%    6<   �� *TradeNames.BusinessName+  5       $ Adres��6%    64   �� *Addresses[0].FullAddress+  5!      $ Branche Nummer��6%    6=   �� *BranchNumber+  5"      $
 RSIN��6%    63   �� *RSIN+  5#      $  HasEntryInBusinessRegister��6%    6I   �� *HasEntryInBusinessRegister+  5$      $ HasNonMailingIndication��6%    6F   �� *HasNonMailingIndication+  5%      $ IsLegalPerson��6%    6<   �� *IsLegalPerson+  5&      $ IsBranch��6%    67   �� *
IsBranch+  5'      $ IsMainBranch��6%    6;   �� *IsMainBranch+5)      5*      5+      