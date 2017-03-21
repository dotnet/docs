            Url url = new Url("http://www.treyresearch.com");
            Console.WriteLine("Adding host evidence " + url.ToString());
            ev2a.AddHost(url);
            Evidence ev2b = new Evidence(ev2a);
            Console.WriteLine("Copy evidence into new evidence");
            IEnumerator enum1 = ev2b.GetHostEnumerator();
            enum1.MoveNext();
            Console.WriteLine(enum1.Current.ToString());