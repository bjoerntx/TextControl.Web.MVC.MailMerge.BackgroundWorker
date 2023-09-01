using Microsoft.AspNetCore.Mvc;

namespace tx_wp_api.Controllers {
	[ApiController]
	public class DocumentProcessingController : ControllerBase {
		
		private readonly ILogger<DocumentProcessingController> _logger;

		public DocumentProcessingController(ILogger<DocumentProcessingController> logger) {
			_logger = logger;
		}

		[Route("api/[controller]/merge")]
		[HttpPost]
		public ProcessingRequest Post(string webHookUrl) {

			ProcessingRequest request = new ProcessingRequest() {
				WebHookUrl = webHookUrl
			};

			request.Create(Url.ActionLink("Get", "DocumentProcessing", new { id = "1" }));

			return request;
		}

		[Route("api/[controller]/{id}")]
		[HttpGet]
		public string Get([FromRoute] string id) {

			ProcessingRequest request = new ProcessingRequest(id);
			return request.RetrieveDocument();
		}
	}
}