//
// System.Configuration.ConfigurationPropertyCollection.cs
//
// Authors:
//	Duncan Mak (duncan@ximian.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
// Copyright (C) 2004 Novell, Inc (http://www.novell.com)
//

#if NET_2_0
using System;
using System.Collections;
using System.Collections.Generic;

namespace System.Configuration
{
	public class ConfigurationPropertyCollection : ICollection, IEnumerable
	{
		List <ConfigurationProperty> collection;

		public ConfigurationPropertyCollection ()
		{
			collection = new List <ConfigurationProperty> ();
		}

		public int Count {
			get { return collection.Count; }
		}

		public ConfigurationProperty this [string name] {
			get {
				foreach (ConfigurationProperty cp in collection)
					if (cp.Name == name)
							return cp;

				return null;
			}
		}

		public bool IsSynchronized {
			get {  return false; }
		}

		public object SyncRoot {
			get { return collection; }
		}

		public void Add (ConfigurationProperty property)
		{
			collection.Add (property);
		}

		public bool Contains (string name)
		{
			ConfigurationProperty property = this [name];

			if (property == null)
				return false;
			
			return collection.Contains (property);
		}

		public void CopyTo (ConfigurationProperty [] array, int index)
		{
			collection.CopyTo (array, index);
		}

		void ICollection.CopyTo (Array array, int index)
		{
			((ICollection) collection).CopyTo (array, index);
		}

		public IEnumerator GetEnumerator ()
		{
			return collection.GetEnumerator ();
		}

		public bool Remove (string name)
		{
			return collection.Remove (this [name]);
		}
		
		public void Clear ()
		{
			collection.Clear ();
		}
	}
}
#endif
