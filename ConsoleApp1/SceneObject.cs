using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Hierarchies
{
    public class SceneObject
    {
        protected SceneObject parent = null;
        protected List<SceneObject> children = new List<SceneObject>();

        protected Matrix3 localTransform = new Matrix3();
        protected Matrix3 globalTransform = new Matrix3();

        /// <summary>
        /// Returns the parent
        /// </summary>
        public SceneObject Parent
        {
            get { return parent; }
        }
        /// <summary>
        /// Returns the Local Transform
        /// </summary>
        public Matrix3 LocalTransform
        {
            get { return localTransform; }
        }
        /// <summary>
        /// Returns the Global transform
        /// </summary>
        public Matrix3 GlobalTransform
        {
            get { return globalTransform; }
        }
        /// <summary>
        /// Updates the transform
        /// </summary>
        public void UpdateTransform()
        {
            if (parent != null)
                globalTransform = parent.globalTransform * localTransform;
            else
                globalTransform = localTransform;
            foreach (SceneObject child in children)
                child.UpdateTransform();
        }
        /// <summary>
        /// Sets the position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetPosition(float x, float y)
        {
            localTransform.SetTranslation(x, y);
            UpdateTransform();
        }
        /// <summary>
        /// Sets the rotate
        /// </summary>
        /// <param name="radians"></param>
        public void SetRotate(float radians)
        {
            localTransform.SetRotateZ(radians);
            UpdateTransform();
        }
        /// <summary>
        /// Sets the scale
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetScale(float width, float height)
        {
            localTransform.SetScaled(width, height, 1);
            UpdateTransform();
        }
        /// <summary>
        /// Translate the object
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Translate(float x, float y)
        {
            localTransform.Translate(x, y);
            UpdateTransform();
        }
        /// <summary>
        /// Rotates the object
        /// </summary>
        /// <param name="radians"></param>
        public void Rotate(float radians)
        {
            localTransform.RotateZ(radians);
            UpdateTransform();
        }
        /// <summary>
        /// Scales the object
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void Scale(float width, float height)
        {
            localTransform.Scale(width, height, 1);
            UpdateTransform();
        }

        public SceneObject()
        {

        }
        /// <summary>
        /// What it does before we brutaly kill it
        /// </summary>
        ~SceneObject()
        {
            if (parent != null)
            {
                parent.RemoveChild(this);
            }
            foreach (SceneObject so in children)
            {
                so.parent = null;
            }
        }

        public virtual void OnUpdate(float delatTime)
        {

        }
        public virtual void OnDraw()
        {

        }
        /// <summary>
        /// the update step for the object 
        /// </summary>
        /// <param name="deltaTime"></param>
        public void Update(float deltaTime)
        {
            OnUpdate(deltaTime);
            foreach (SceneObject child in children)
            {
                child.Update(deltaTime);
            }
        }
        public void Draw()
        {
            OnDraw();
            foreach (SceneObject child in children)
            {
                child.Draw();
            }
        }

        public int GetChildCount()
        {
            return children.Count;
        }

        public void AddChild(SceneObject child)
        {
            Debug.Assert(child.parent == null);
            child.parent = this;
            children.Add(child);
        }

        public void RemoveChild(SceneObject child)
        {
            if(children.Remove(child) == true)
            {
                child.localTransform.Set(globalTransform);
                child.parent = null;
            }
        }
        public SceneObject GetChild(int index)
        {
            return children[index];
        }
    }
}
