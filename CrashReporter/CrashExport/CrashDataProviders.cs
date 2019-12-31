﻿namespace RJCP.Diagnostics.CrashExport
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    internal class CrashDataProviders : Collection<ICrashDataExport>
    {
        private HashSet<ICrashDataExport> m_Providers = new HashSet<ICrashDataExport>();

        protected override void InsertItem(int index, ICrashDataExport item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (m_Providers.Contains(item))
                throw new ArgumentException("Item is already in collection", nameof(item));

            m_Providers.Add(item);
            base.InsertItem(index, item);
        }

        protected override void SetItem(int index, ICrashDataExport item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (item.Equals(base[index]) || !m_Providers.Contains(item)) {
                m_Providers.Remove(base[index]);
                m_Providers.Add(item);
                base.SetItem(index, item);
                return;
            }

            throw new ArgumentException("Item is already in collection", nameof(item));
        }

        protected override void RemoveItem(int index)
        {
            m_Providers.Remove(base[index]);
            base.RemoveItem(index);
        }
    }
}