package com.itheima.web;

import com.itheima.mapper.SongMapper;
import com.itheima.pojo.Song;
//import com.itheima.util.SqlSessionFactoryUtils;
import org.apache.ibatis.io.Resources;
import org.apache.ibatis.session.SqlSession;
import org.apache.ibatis.session.SqlSessionFactory;
import org.apache.ibatis.session.SqlSessionFactoryBuilder;

import javax.servlet.*;
import javax.servlet.http.*;
import javax.servlet.annotation.*;
import java.io.IOException;
import java.io.InputStream;
import java.io.PrintWriter;
import java.util.Arrays;
import java.util.List;
import com.alibaba.fastjson.JSON;

@WebServlet("/test")
/**
 * Mybatis 快速入门代码
 */
public class Test_qr_ extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		System.out.println("servlet");
		request.setCharacterEncoding("UTF-8");	
		String qrcode="";
		try{
			qrcode = request.getParameter("qrcode");
		}
		catch(Exception e){
		}
		//System.out.println(singer);
       
	   

		response.setContentType("text/html;charset=UTF-8"); 
		response.getWriter().print("{Code: 200,Message:"+qrcode+"}");



    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        this.doGet(request, response);
    }
}