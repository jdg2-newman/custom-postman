using CustomPostman;

namespace CustomPostmanUI
{
    public partial class Dashboard : Form
    {
        private readonly IApiAccess api;

        public Dashboard()
        {
            InitializeComponent();
            api = api ?? throw new ArgumentNullException(nameof(api));
            httpVerbSelection.SelectedItem = "GET";
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private async void callAPI_Click(object sender, EventArgs e)
        {
            systemStatus.Text = "Calling API...";
            resultsText.Text = "";

            if (api.ValidateUrl(apiText.Text) == false)
            {
                systemStatus.Text = "Invalid URL";
                return;
            }

            HttpAction action;
            if(Enum.TryParse(httpVerbSelection.SelectedItem!.ToString(), out action) == false)
            {
                systemStatus.Text = "Invalid HTTP Verb";
                return;
            }

            try
            {
                resultsText.Text = await api.CallApiAsync(apiText.Text, bodyText.Text, action);

                callData.SelectedTab = resultsTab;

                resultsTab.Focus();

                systemStatus.Text = "Ready";
            }
            catch (Exception ex)
            {

                resultsText.Text = "Error: " + ex.Message;
                systemStatus.Text = "Error";
            }
        }

        private void resultsLabel_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
