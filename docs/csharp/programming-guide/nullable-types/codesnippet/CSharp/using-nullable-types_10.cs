            int? e = null;
            int? f = null;

            // g = e or f, unless e and f are both null, in which case g = -1.
            int g = e ?? f ?? -1;