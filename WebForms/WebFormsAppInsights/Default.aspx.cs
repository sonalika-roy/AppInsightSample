using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsAppInsights
{
    public partial class _Default : Page
    {
        TelemetryClient _telemetryClient;

        public _Default()
        {
            _telemetryClient = new TelemetryClient();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _telemetryClient.TrackTrace("WebFormsAppInsights - Default page loaded.");
        }
    }
}