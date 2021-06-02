using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using GDCui.Helpers;

namespace GDCui.ViewModel
{
    public class HomeViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; }

        private CompanyViewModel companyVM = new CompanyViewModel();
        private EmployeeViewModel employeeVM = new EmployeeViewModel();
        private GameViewModel gameVM = new GameViewModel();
        private GameBlueprintViewModel blueprintVM = new GameBlueprintViewModel();
        private BetaVersionViewModel betaVM = new BetaVersionViewModel();
        private ArtViewModel artVM = new ArtViewModel();
        private CodeViewModel codeVM = new CodeViewModel();
        private GameBetaVersionViewModel gameBetaVM = new GameBetaVersionViewModel();
        private ArtArtistViewModel artArtistVM = new ArtArtistViewModel();
        private ArtTesterViewModel artTesterVM = new ArtTesterViewModel();
        private CodeArtViewModel codeArtVM = new CodeArtViewModel();
        private CodeProgrammerViewModel codeProgrammerVM = new CodeProgrammerViewModel();
        private TesterBetaVersionViewModel testerBetaVM = new TesterBetaVersionViewModel();
        private GameDesignerGameBlueprintViewModel designerBlueprintVM = new GameDesignerGameBlueprintViewModel();
        private GameBlueprintCodeViewModel blueprintCodeVM = new GameBlueprintCodeViewModel();

        private BindableBase currentVM = new BindableBase();
        public BindableBase CurrentVM
        {
            get { return currentVM; }

            set
            {
                SetProperty(ref currentVM, value);
            }
        }

        public HomeViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
            CurrentVM = companyVM;
        }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "companyView":
                    CurrentVM = companyVM;
                    break;
                case "employeeView":
                    CurrentVM = employeeVM;
                    break;
                case "gameView":
                    CurrentVM = gameVM;
                    break;
                case "blueprintView":
                    CurrentVM = blueprintVM;
                    break;
                case "betaView":
                    CurrentVM = betaVM;
                    break;
                case "artView":
                    CurrentVM = artVM;
                    break;
                case "codeView":
                    CurrentVM = codeVM;
                    break;
                case "gameBetaView":
                    CurrentVM = gameBetaVM;
                    break;
                case "artTesterView":
                    CurrentVM = artTesterVM;
                    break;
                case "artArtistView":
                    CurrentVM = artArtistVM;
                    break;
                case "codeArtView":
                    CurrentVM = codeArtVM;
                    break;
                case "codeProgrammerView":
                    CurrentVM = codeProgrammerVM;
                    break;
                case "testerBetaView":
                    CurrentVM = testerBetaVM;
                    break;
                case "designerBlueprintView":
                    CurrentVM = designerBlueprintVM;
                    break;
                case "blueprintCodeView":
                    CurrentVM = blueprintCodeVM;
                    break;
            }
        }
    }
}
