using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace React_ASP_NET.Models
{
    public class CandidateRepository : ICandidateRepository, IDisposable
    {
        private CandidateContext context;
        public CandidateRepository(CandidateContext context)
        {
            this.context = context;
        }

        public IEnumerable<Candidate> GetAll()
        {
            return context.Candidates.ToList();
        }
       
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}