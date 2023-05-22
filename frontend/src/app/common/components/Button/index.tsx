import React from "react";

enum ButtonColors {
  green = "bg-green-700",
  red = "bg-red-700",
}

enum ButtonColorsHover {
  green = "hover:bg-green-900",
  red = "hover:bg-red-900",
}

interface IButtonProps extends React.ButtonHTMLAttributes<HTMLButtonElement> {
  title: string;
  color?: "green" | "red";
}

const Button = ({ title, color, ...props }: IButtonProps) => {
  return (
    <button
      {...props}
      className={`${
        ButtonColors[color ?? "green"]
      } text-white p-2 rounded-md shadow-md ${
        ButtonColorsHover[color ?? "green"]
      } transition-all ${props.className}`}
    >
      {title}
    </button>
  );
};

export default Button;
