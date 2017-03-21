		HttpResponseMessageProperty responseProperty =
			new HttpResponseMessageProperty();
		responseProperty.StatusCode = HttpStatusCode.OK;
		responseProperty.Headers.Add(
					     HttpResponseHeader.ContentType,
					     "text/html; charset=UTF-8");