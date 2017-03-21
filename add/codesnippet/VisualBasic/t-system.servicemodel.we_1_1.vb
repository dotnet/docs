            counter = counter + 1

            Dim match As UriTemplateMatch = WebOperationContext.Current.IncomingRequest.UriTemplateMatch
            Dim template As New UriTemplate("{id}")

            customer.Uri = template.BindByPosition(match.BaseUri, counter.ToString())
            customers(counter.ToString()) = customer
            WebOperationContext.Current.OutgoingResponse.SetStatusAsCreated(customer.Uri)