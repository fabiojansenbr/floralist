﻿using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Services
{
    public interface IRepository : IDisposable
    {
        IQueryable<Image> Images { get; }
        IQueryable<Proposal> Proposals{ get; }
        IQueryable<ProposalItem> ProposalItems { get; }
        IQueryable<Customer> Customers { get; }
        IQueryable<Designer> Designers { get; }

        Task AddProposalItemAsync(int proposalId, ProposalItem proposalItem);

        Task AddProposalAsync(Proposal proposal);
        Task<Proposal> GetProposalAsync(int? id);
        Task UpdateProposalAsync(int id, Proposal proposal);
        Task DeleteProposalAsync(int id);
        List<ProposalItem> GetProposalItemsForProposal(int id);
    }
}
