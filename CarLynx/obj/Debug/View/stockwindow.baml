   M S B A M L   `   `   `  ����B  >CarLynx, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:CarLynx.ViewCarLynx.View  5   	   h dSAPBusinessObjects.WPF.Viewer, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304tRclr-namespace:SAPBusinessObjects.WPF.Viewer;assembly=SAPBusinessObjects.WPF.ViewerSAPBusinessObjects.WPF.Viewer 5   	       CarLynx.View.stockwindow   5   	   n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:CarLynx.View     5   	   eViewerRclr-namespace:SAPBusinessObjects.WPF.Viewer;assembly=SAPBusinessObjects.WPF.Viewer     5   	     � WindowStyle$
  None=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � Title$ stockwindow��5   	   $	��800��6   $
��1200��6*    � 	Resources 5       �� 
TargetType   btncutsomstyle �� Property �� Value �� 
TargetType ��Name	 �� CornerRadius
 J� RenderTransformOrigin �� ScaleX �� ScaleY �� Triggers P� Property P� Value �� 
TargetName N� EnterActions �� 
TargetName �� TargetProperty	 W� To g� Duration N� ExitActions��%  &	        �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ border��6!   $	 10��61   #��z��6C   #��z��5   
   #��z��5   
   $
 0.5,0.5&�5   
   z�5      �� 5   "   $ 1Q�61   $ 1Q�6<   ._�5      �� $��Center=�6/   $��Center=�6L   5       5      P� 5       �@J�IsMouseOver . . �5   "   �� $ border��6)    � �� �	#FFEAEAEA6T    5   "   �� 5   &   .��5    *   �� .��5!   .   W� $ border��6>   $ RenderTransform.ScaleX�5"   '   $	 0.9X�5#   '   $ 0:0:0.2D�60   W� 5$   .   $ border��6>   $ RenderTransform.ScaleY�5%   '   $	 0.9X�5&   '   $ 0:0:0.2D�60   5'   +   5(   '    5*   "   �� 5+   &   .��5,   *   �� .��5-   .   W� $ border��6>   $ RenderTransform.ScaleX�5.   '   $ 1X�5/   '   $ 0:0:0.1D�6.   W� 50   .   $ border��6>   $ RenderTransform.ScaleY�51   '   $ 1X�52   '   $ 0:0:0.1D�6.   53   +   54   '   56      58      5:      5;      5<      .��5=      � .+�5?   
   8  2SAPBusinessObjects.WPF.Viewer.CrystalReportsViewer  -   5          Name$ 	stockView��5?   &   $��Center=�69   $
��1200��6V   $��0,12,0,0q�6c   �� 5@   
   -   5         ��Name$ closeBtn��5@      #��[  6#    � Cursor$
 Hand��6K   $��Close Window��6Y   $
��Left=�6p   $��152,763,0,0q�6�   $	��Top=�6�   $��19��6�   $	��825��6�   ���	#FF797676��5A      �� 5B       �� Color$ White��6"    �� Opacity$	 0.6Q�60   5D      5E      5F      