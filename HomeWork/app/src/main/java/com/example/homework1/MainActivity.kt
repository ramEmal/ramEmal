package com.example.homework1

import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity

public class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val button = findViewById<Button>(R.id.button)
        button.setOnClickListener{
            val Name=findViewById<EditText>(R.id.editTextTextPersonName).text.toString()
            val Age =findViewById<EditText>(R.id.age).text.toString().toInt()
            val Weight=findViewById<EditText>(R.id.weight).text.toString().toFloat()
            val Height=findViewById<EditText>(R.id.height).text.toString().toInt()
            var flag:Boolean=false
            if(Height>250||Height<0){
                Toast.makeText(this,"Некоректно введен рост",Toast.LENGTH_SHORT).show()
                flag=true
            }
            if (Age>150||Age<0){
                Toast.makeText(this,"Некоректно введен возраст",Toast.LENGTH_SHORT).show()
                flag=true
            }
            if (Weight>250||Weight<0){
                Toast.makeText(this,"Некоректно введен вес",Toast.LENGTH_SHORT).show()
                flag=true
            }
            if(Name==""||Name.length>50){
                Toast.makeText(this,"Некоректно введено имя",Toast.LENGTH_SHORT).show()
                flag=true
            }
            if(!flag){
                val view =findViewById<TextView>(R.id.out)
                view.text=(Weight+Height-Age+Name.length).toInt().toString()
            }
        }
    }
}
