                counter++;
                
                UriTemplateMatch match = WebOperationContext.Current.IncomingRequest.UriTemplateMatch;

                UriTemplate template = new UriTemplate("{id}");
                customer.Uri = template.BindByPosition(match.BaseUri, counter.ToString());

                customers[counter.ToString()] = customer;
                
                WebOperationContext.Current.OutgoingResponse.SetStatusAsCreated(customer.Uri);
                