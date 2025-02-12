#include <iostream>
#include <fstream>
#include <sstream>
#include <string>
#include <queue>
using namespace std;
struct Player
{
	string name;
	int day, month, year;
	int height_cm;
	int weight_kg;
	string nationality;
	string club_name;
};
struct Node
{
	Player base;
	Node* left;
	Node* right;
};
void insert(Node*& root, Node* newNode)
{
	if (root == NULL)
		root = newNode;
	else if (root->base.name > newNode->base.name)
		insert(root->left, newNode);
	else 
		insert(root->right, newNode);
}
Node* createPlayerTree(string filename)
{
	Node* root = NULL;
	fstream infile(filename);
	string line;
	getline(infile, line, '\n');
	while (getline(infile, line, '\n'))
	{
		stringstream ss(line);
		Player a;
		getline(ss, a.name, ',');
		ss >> a.day; ss.ignore();
		if (a.day > 15)
			continue;
		ss >> a.month; ss.ignore();
		ss >> a.year; ss.ignore();
		ss >> a.height_cm; ss.ignore();
		ss >> a.weight_kg; ss.ignore();
		getline(ss, a.nationality, ',');
		getline(ss, a.club_name, '\n');
		Node* newNode = new Node{ a, NULL, NULL };
		insert(root, newNode);
	}
	infile.close();
	return root;
}
// cau c
int levelNode(Node* root, Node* node)
{
	if (root == node)
		return 0;
	int level = 0;
	Node* cur = root;
	while (cur != node)
	{
		if (cur->base.name > node->base.name)
			cur = cur->left;
		else
			cur = cur->right;
		level++;
	}
	return level;
}
void PlayerTreeTraversal(Node* pRoot)
{
	if (pRoot == NULL)
		return;

	queue <Node*> q;
	q.push(pRoot);
	while (!q.empty())
	{
		Node* cur = q.front();
		cout << levelNode(pRoot, cur) << " - " << cur->base.name << " - " << cur->base.club_name << " - " << cur->base.year << '\n';
		if (cur->left != NULL) q.push(cur->left);
		if (cur->right != NULL) q.push(cur->right);
		q.pop();
	}
}
// cau d
void removeNode(Node*& root, Player a)
{
	if (root == NULL)
		return;
	else if (root->base.name > a.name)
		removeNode(root->left, a);
	else  if (root->base.name < a.name)
		removeNode(root->right, a);
	else
	{
		if (root->left == NULL) {
			Node* del = root;
			root = root->right;
			delete del;
		}
		else if (root->right == NULL) {
			Node* del = root;
			root = root->left;
			delete del;
		}
		else {
			Node* cur = root->right;
			while (cur->left != NULL)
				cur = cur->left;
			root->base = cur->base;
			removeNode(root->right, cur->base);
		}
	}
}
void removePlayers(Node*& pRoot, char C)
{
	if (pRoot == NULL)
		return;
	removePlayers(pRoot->left, C);
	removePlayers(pRoot->right, C);
	if (pRoot->base.name[0] == C)
		removeNode(pRoot, pRoot->base);
}
// cau e
void findPlayers(Node* pRoot)
{
	if (pRoot == NULL)
		return;

	queue <Node*> q;
	q.push(pRoot);
	while (!q.empty())
	{
		Node* cur = q.front();
		if (cur->left != NULL && cur->right != NULL)
			if (cur->base.height_cm + cur->left->base.height_cm + cur->right->base.height_cm > 550)
				cout << levelNode(pRoot, cur) << " - " << cur->base.name << '\n';
		if (cur->left != NULL) q.push(cur->left);
		if (cur->right != NULL) q.push(cur->right);
		q.pop();
	}
}
int main()
{
	Node* root = createPlayerTree("Players-1.csv");
	PlayerTreeTraversal(root);
	removePlayers(root, 'M');
	PlayerTreeTraversal(root);
	//findPlayers(root);
}