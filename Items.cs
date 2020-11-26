using System;

namespace Items
{
    public enum Color {
            Red,
            Yellow,
            Blue,
            Orange,
            Green,
            Violet,
            White,
            Black
    }
    public interface Shape {
        public bool IsRegular();
        public double Area();
        public double Perimeter();
        public void Deconstruct(out bool isRegular, out double area, out double perimeter);
    }

    public class Quadrilateral : Shape {
        double side_1;
        double side_2; 
        double side_3;
        double side_4;

        double ang_1_2;
        double ang_2_3;
        double ang_3_4;
        double ang_4_1;

        public Color color;

        public Quadrilateral(Color color, double side_1, double side_2, double side_3, double side_4, double ang_1_2, double ang_2_3, double ang_3_4, double ang_4_1) {
            
            
            this.side_1 = side_1;
            this.side_2 = side_2;
            this.side_3 = side_3;
            this.side_4 = side_4;

            this.ang_1_2 = ang_1_2;
            this.ang_2_3 = ang_2_3;
            this.ang_3_4 = ang_3_4;
            this.ang_4_1 = ang_4_1;

            this.color = color;
        }

        public virtual bool IsRegular() {
            var result = true;

            result &= side_1 == side_2;
            result &= side_1 == side_3;
            result &= side_1 == side_4;
            result &= ang_1_2 == Math.PI / 2.0;
            result &= ang_2_3 == Math.PI / 2.0;
            result &= ang_3_4 == Math.PI / 2.0;
            result &= ang_4_1 == Math.PI / 2.0;

            return result;
        }

        public virtual double Area() {
            var area_half_triangle_1 = side_1*side_2*Math.Sin(ang_1_2) / 2.0;
            var area_half_triangle_2 = side_3*side_4*Math.Sin(ang_3_4) / 2.0;
            return area_half_triangle_1 + area_half_triangle_2;
        }

        public virtual double Perimeter() {
            return side_1 + side_2 + side_3 + side_4;
        }

        public void Deconstruct(out bool isRegular, out double area, out double perimeter) {
            isRegular = IsRegular();
            area = Area();
            perimeter = Perimeter();
        }
    }

    public class Rectangle : Quadrilateral {
        double side_1;
        double side_2; 

        public Rectangle(Color color, double side_1, double side_2) : base(color, side_1, side_2, side_1, side_2, Math.PI / 2.0, Math.PI / 2.0, Math.PI / 2.0, Math.PI / 2.0){
            this.side_1 = side_1;
            this.side_2 = side_2; 
        }

        public override bool IsRegular() {
            return side_1 == side_2;
        }

        public override double Area() {
            return side_1*side_2;
        }

        public override double Perimeter() {
            return side_1*2 + side_2*2;
        }
    }

    public class Square : Rectangle {
        double side;

        public Square(Color color, double side) : base(color, side, side) {
            this.side = side;
        }

        public override bool IsRegular() {
            return true;
        }

        public override double Area() {
            return side*side;
        }

        public override double Perimeter() {
            return side*4;
        }
    }

    public class Triangle : Shape {
        double side_1;
        double side_2; 
        double side_3;

        double ang_1_2;
        double ang_2_3;
        double ang_3_1;

        public Triangle(double side_1, double side_2, double side_3, double ang_1_2, double ang_2_3, double ang_3_1) {
            this.side_1 = side_1;
            this.side_2 = side_2; 
            this.side_3 = side_3;

            this.ang_1_2 = ang_1_2;
            this.ang_2_3 = ang_2_3;
            this.ang_3_1 = ang_3_1;
        }

        public bool IsRegular() {
            var result = true;

            result &= side_1 == side_2;
            result &= side_1 == side_3;

            result &= ang_1_2 == Math.PI / 3.0;
            result &= ang_2_3 == Math.PI / 3.0;
            result &= ang_3_1 == Math.PI / 3.0;

            return result;
        }

        public double Area() {
            return side_1 * side_2 * Math.Sin(ang_1_2) / 2;
        }

        public double Perimeter() {
            return side_1 + side_2 + side_3;
        }

        public void Deconstruct(out bool isRegular, out double area, out double perimeter) {
            isRegular = IsRegular();
            area = Area();
            perimeter = Perimeter();
        }
    }
}
