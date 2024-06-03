using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace TD03
{
    /// <summary>
    /// A 2D-vector
    /// </summary>
    internal class Vector2D
    {
        private double x;
        private double y;

        /// <summary>
        /// Init the vector
        /// </summary>
        /// <param name="x">x-coordinate (0 if omitted)</param>
        /// <param name="y">y-coordinate (0 if omitted)</param>
        public Vector2D(double x = 0, double y=0)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Create a vector from another vector
        /// </summary>
        /// <param name="other">other vector</param>
        public Vector2D(Vector2D other)
        {
            this.x = other.x;
            this.y = other.y;
        }

        /// <summary>
        /// Gets the X-coordinate
        /// </summary>
        public double X => x;
        

        /// <summary>
        /// Gets the Y-coordinate
        /// </summary>
        public double Y => y;
            
        /// <summary>
        /// Gets the module (length) of the vector
        /// </summary>
        public double Module => Math.Sqrt(x * x + y * y);

        /// <summary>
        /// Gets the argument (in radians) of the vector
        /// </summary>
        public double Argument => Math.Atan2(y, x);
        

        /// <summary>
        /// Defines operator + for Vector 2D
        /// </summary>
        /// <param name="left">left operand</param>
        /// <param name="right">right operand</param>
        /// <returns>left+right</returns>
        public static Vector2D operator+(Vector2D left, Vector2D right)
        {
            Vector2D sum = new Vector2D();
            sum.x = left.x + right.x;
            sum.y = left.y + right.y;
            return sum;
        }

        

        /// <summary>
        /// Definies operator * for vector and real number
        /// </summary>
        /// <param name="vector">vector</param>
        /// <param name="coef">real number</param>
        /// <returns>a new vector</returns>
        public static Vector2D operator*(Vector2D vector, double coef)
        {
            Vector2D newVector = new Vector2D(vector);
            newVector.x *= coef;
            newVector.y *= coef;
            return newVector;
        }

        /// <summary>
        /// Definies operator * for vector and real number
        /// </summary>
        /// <param name="vector">vector</param>
        /// <param name="coef">real number</param>
        /// <returns>a new vector</returns>
        public static Vector2D operator*(double coef, Vector2D vector)
        {
            return vector * coef;
        }

        public override bool Equals(object? obj)
        {
            return obj is Vector2D d &&
                   x == d.x &&
                   y == d.y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }
    }
}
