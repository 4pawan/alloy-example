using EPiServer.AddOns.Helpers;
using EPiServer.Forms.Core.Data;
using EPiServer.Forms.Core.Models;
using EPiServer.Globalization;
using EPiServer.ServiceLocation;
using System.Globalization;

namespace alloy_example.Customization.Forms;

public class FormsCRUD
{
    public static readonly string SYSTEMCOLUMN_FinalizedSubmission = "FinalizedSubmission";
    public static readonly Injected<FormDataRepository> _formDataRepository;
    public static readonly Injected<DdsPermanentStorage> _permanentStorage;

    public static void CreateFormData()
    {
        ContentReference formContainer = new ContentReference(1234); // Example content reference, replace with actual reference 
        var formDataList = new List<CustomFormData>();

        for (int row = 0; row < 10; row++)
        {
            var formData = new CustomFormData();
            formData.KeyValueList = new List<KeyValuePair<string, object>>();
            for (int column = 0; column < 5; column++)
            {
                //read each row as keyvalue list.                
                formData.KeyValueList.Add(new KeyValuePair<string, object>("key", "value"));
            }

            formDataList.Add(formData);
        }

        var formIdentity = new FormIdentity(formContainer.GetContentGuid(), ContentLanguage.PreferredCulture.Name);
        var existingData = _formDataRepository.Service.GetSubmissionData(formIdentity, DateTime.MinValue, DateTime.MaxValue);
        var submission = new Submission() { Data = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase) };
        submission.Data.Add("SYSTEMCOLUMN_FinalizedSubmission", false);
        submission.Data.Add("SYSTEMCOLUMN_SubmitUser", "");
        submission.Data.Add("SYSTEMCOLUMN_Language", ContentLanguage.PreferredCulture.Name);
        DateTime submitedTime = DateTime.MinValue;
        var DateTimeFormats = new string[] { "MM/dd/yyyy hh:mm:ss tt", "yyyy-MM-dd hh:mm:ss" };
        DateTime.TryParseExact("", DateTimeFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out submitedTime);
        submission.Data.Add("SYSTEMCOLUMN_SubmitTime", submitedTime.ToUniversalTime());
        var savedSubmissionId = _permanentStorage.Service.SaveToStorage(formIdentity, submission);
    }
}
//a single submisssion data is list<string,Object>..so multiple submissions are List<List<string, Object>> 
public class CustomFormData
{
    public List<KeyValuePair<string, object>> KeyValueList { get; set; }
}