   M S B A M L   `   `   `  ����@  <GDCui, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GDCuiGDCui  5   	   'clr-namespace:GDCui.View
GDCui.View  5   	   1clr-namespace:GDCui.ViewModelGDCui.ViewModel  5   	       GDCui.View.HomeView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:GDCui     5   	   *viewsclr-namespace:GDCui.View     5   	   3	viewModelclr-namespace:GDCui.ViewModel     5   	     � Title$  HomeView��5
   	   $	��800��6   $
��1200��6'    � WindowStartupLocation$ CenterScreen=�64    � DataContext 5      #   GDCui.ViewModel.HomeViewModel  5   
    � 	Resources 5       �� DataType&    GDCui.ViewModel.CompanyViewModel   GDCui.View.CompanyView'   !GDCui.ViewModel.EmployeeViewModel   GDCui.View.EmployeeView#   GDCui.ViewModel.GameViewModel   GDCui.View.GameView,   &GDCui.ViewModel.GameBlueprintViewModel"	   GDCui.View.GameBlueprintView*
   $GDCui.ViewModel.BetaVersionViewModel    GDCui.View.BetaVersionView"   GDCui.ViewModel.ArtViewModel   GDCui.View.ArtView#   GDCui.ViewModel.CodeViewModel   GDCui.View.CodeView.   (GDCui.ViewModel.GameBetaVersionViewModel$   GDCui.View.GameBetaVersionView(   "GDCui.ViewModel.ArtArtistViewModel   GDCui.View.ArtArtistView(   "GDCui.ViewModel.ArtTesterViewModel   GDCui.View.ArtTesterView&    GDCui.ViewModel.CodeArtViewModel   GDCui.View.CodeArtView-   'GDCui.ViewModel.CodeProgrammerViewModel#   GDCui.View.CodeProgrammerView0   *GDCui.ViewModel.TesterBetaVersionViewModel&    GDCui.View.TesterBetaVersionView8   2GDCui.ViewModel.GameDesignerGameBlueprintViewModel.   (GDCui.View.GameDesignerGameBlueprintView0   *GDCui.ViewModel.GameBlueprintCodeViewModel&    GDCui.View.GameBlueprintCodeView��%e  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5      *, +)(�� �     5      *,
 +)(�� �     5       *, +)(�� ,    5#      *, +)(�� ^    5&      *, +)(�� �    5)      *, +)(�� �    5,      *, +)(�� �    5/      *, +)(�� &    52      *, +)(�� X    55      *, +)(�� �    58      *, +)(�� �    5;      *, +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5      	  5      �� 5   
   " 
 6   .R�5        5      �� 5    
   "  6   .R�5!        5"      �� 5#   
   "  6   .R�5$        5%      �� 5&   
   "  6   .R�5'        5(      �� 5)   
   "  6   .R�5*        5+      �� 5,   
   "  6   .R�5-        5.      �� 5/   
   "  6   .R�50        51      �� 52   
   "  6   .R�53        54      �� 55   
   "  6   .R�56        57      �� 58   
   "  6   .R�59        5:      �� 5;   
   "  6   .R�5<        5=      5@      .��5B      � .+�5C   
   ]� .+�5D      o� $	��Top=�6   .@�5E      m� $��Company��6    m� CommandParameter$ companyView��6K    m� Command 6,   �� *
NavCommand+6K   m� 5F      $��Employee��6   $ employeeView��6L    6-   �� *
NavCommand+6L   m� 5G      $
��Game��6   $ gameView��6H    6)   �� *
NavCommand+6H   m� 5H      $��	Blueprint��6   $ blueprintView��6M    6.   �� *
NavCommand+6M   m� 5I      $
��Beta��6   $ betaView��6H    6)   �� *
NavCommand+6H   m� 5J      $	��Art��6   $ artView��6G    6(   �� *
NavCommand+6G   m� 5K      $
��Code��6   $ codeView��6H    6)   �� *
NavCommand+6H   m� 5L      $��GameBeta��6   $ gameBetaView��6L    6-   �� *
NavCommand+6L   m� 5M      $��	ArtArtist��6   $ artArtistView��6M    6.   �� *
NavCommand+6M   m� 5N      $��	ArtTester��6   $ artTesterView��6M    6.   �� *
NavCommand+6M   m� 5O      $��CodeArt��6   $ codeArtView��6K    6,   �� *
NavCommand+6K   m� 5P      $��CodeProgrammer��6   $ codeProgrammerView��6R    63   �� *
NavCommand+6R   m� 5Q      $��
TesterBeta��6   $ testerBetaView��6N    6/   �� *
NavCommand+6N   m� 5R      $��DesignerBlueprint��6   $ designerBlueprintView��6U    66   �� *
NavCommand+6U   m� 5S      $��BlueprintCode��6   $ blueprintCodeView��6Q    62   �� *
NavCommand+6Q   5U      �� 5W      ��6   �� *	CurrentVM+5X      5Y      5Z      