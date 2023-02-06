using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper {
	class TreeNode {

		private TreeNode _parent;
		private List<TreeNode> _children;
		private Cella _cella;
		private string _mossa;

		public TreeNode (TreeNode parent, Cella cella, string mossa) {
			_parent = parent;
			_cella = cella;
			_mossa = mossa;
			_children = new List<TreeNode>();
			_mossa = mossa;
		}

		public List<TreeNode> Children {
			get { return _children; }
		}

		public TreeNode Parent {
			get { return _parent; }
		}

		public Cella Cella {
			get { return _cella; }
		}

		public void AddChild (TreeNode child) {
			_children.Add(child);
		}

		public string Mossa {
			get { return _mossa; }
		}


	}
}
