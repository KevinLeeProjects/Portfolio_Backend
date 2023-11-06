using System.ComponentModel.DataAnnotations;

namespace Portfolio_Backend.Models
{
	public class PortfolioModel
	{
		[Key, Required]
		public string route { get; set; }
		[Required]
        public string skills { get; set; }
        [Required]
        public string blurb { get; set; }
        [Required]
        public string frontendGithub { get; set; }
        [Required]
        public string backendGithub { get; set; }
        [Required]
        public string mainImg { get; set; }

        public string homePageTitle { get; set; }
        public string homePageFrontend { get; set; }
        public string homePageDesktop { get; set; }
        public string homePageMobile { get; set; }

        public string navBarTitle { get; set; }
        public string navBarFrontend { get; set; }
        public string navBarMobileClosed { get; set; }
        public string navBarMobileOpen { get; set; }

        public string adminTitle { get; set; }
        public string adminFrontend { get; set; }
        public string adminBackend { get; set; }
        public string adminDesktop { get; set; }
        public string adminMobile { get; set; }

        public string addProjectTitle { get; set; }
        public string addProjectFrontend { get; set; }
        public string addProjectBackend { get; set; }
        public string addProjectDesktop { get; set; }
        public string addProjectMobile { get; set; }

        
    }
}

