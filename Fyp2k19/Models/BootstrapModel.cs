using Fyp2k19.Code;

namespace Fyp2k19.Models
{
    public class BootstrapModel
    {
        public string ID { get; set; }
        public string AreaLabeledId { get; set; }
        public ModelSize Size { get; set; }
        public string Message { get; set; }
        public string ModalSizeClass
        {
            get
            {
                switch (this.Size)
                {
                    case ModelSize.Small:
                        return "modal-sm";
                    case ModelSize.Large:
                        return "modal-lg";
                    case ModelSize.Medium:
                    default:
                        return "";
                }
            }
        }        
    }
}