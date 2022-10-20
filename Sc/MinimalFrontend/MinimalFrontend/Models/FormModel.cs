using Material.Blazor;

namespace fingerprint.Models;

public class FormModel
{
    public MBSelectElement<string>[] TypeOfContact { get; set; }= {
        new() { SelectedValue = "personal", Label = "persönlich (Offlinemeeting, Face to Face)" },
        new() { SelectedValue = "telefon", Label = "telefonisch" },
        new() { SelectedValue = "chat/messenger", Label = "per Chat/Messenger" },
        new() { SelectedValue = "mail", Label = "per EMail" },
        new() { SelectedValue = "collab", Label = "über Collaborationtools (Jira, Trello etc.)" }
    };
        
    public MBSelectElement<string>[] IntensityOfContact { get; set; }= {
        new() { SelectedValue = "low", Label = "wöchentlich oder seltener" },
        new() { SelectedValue = "normal", Label = "täglich" },
        new() { SelectedValue = "high", Label = "mehrmals täglich" }
    };
        
    public MBSelectElement<string>[] IntensityWishes { get; set; }= {
        new() { SelectedValue = "low", Label = "weniger" },
        new() { SelectedValue = "normal", Label = "passt so" },
        new() { SelectedValue = "high", Label = "mehr" }
    };
        
    public MBSelectElement<string>[] ProblemsWithContact { get; set; }= {
        new() { SelectedValue = "yes", Label = "ja" },
        new() { SelectedValue = "no", Label = "nein" }
    };
        
    public string DropdownSelectionType { get; set; }
    public string DropdownSelectionIntensity { get; set; }
    public string DropdownSelectionWishes { get; set; }
    public string DropdownSelectionProblem { get; set; }
}