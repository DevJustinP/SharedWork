using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAS.Handlers.Handlers
{
    public class SyncFusion
    {
        public SyncFusion()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBMAY9C3t2UVhiQlJPdUBEQmFJfFdmR2ldfVRzckUmHVdTRHRbQl9jTH9bdkVmXXdddXI=");
        }

        public void GeneratePDF(string pHTML, string pFullFilepath)
        {
            try
            {
                //Initialize HTML to PDF converter.
                HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
                //Convert URL to PDF document.
                PdfDocument document = htmlConverter.Convert(pHTML, Path.Combine(AppContext.BaseDirectory, "Docs", "Invoice"));
                //Create the filestream to save the PDF document. 
                FileStream fileStream = new FileStream(pFullFilepath, FileMode.CreateNew, FileAccess.ReadWrite);
                //Save and close the PDF document.
                document.Save(fileStream);
                document.Close(true);
            } catch (Exception ex)
            {
                throw new Exception($"{nameof(SyncFusion)}.{nameof(GeneratePDF)} Error - {ex.Message}");
            }
        }
    }
}
