﻿using CleanArchitecture.Core.Events;
using CleanArchitecture.Core.SharedKernel;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CleanArchitecture.Core.Entities
{
    public class Guestbook : BaseEntity
    {
        public string Name { get; set; }

        private readonly List<GuestbookEntry> _entries = new List<GuestbookEntry>();
        public IEnumerable<GuestbookEntry> Entries => new ReadOnlyCollection<GuestbookEntry>(_entries);

        public void AddEntry(GuestbookEntry entry)
        {
            _entries.Add(entry);
            Events.Add(new EntryAddedEvent(this.Id, entry));
        }
    }
}
