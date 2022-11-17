package com.itheima.web;
import java.util.HashSet;
import java.util.Set;
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

@WebServlet("/savePlaylist")
/**
 * Mybatis 快速入门代码
 */
public class SaveCookieServlet extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		//获取现在添加的歌曲id
		request.setCharacterEncoding("UTF-8");	
		String id = request.getParameter("id");
		//请求cookie获取目前歌单id
		Cookie[] cookies= request.getCookies();
		String idListString="";
		if(cookies!=null){
			for(Cookie cookie:cookies){
				String name=cookie.getName();
				if("id".equals(name)){
					idListString=cookie.getValue();
					break;
				}
			}
			String[] idList=idListString.split("&");
			Set<String> set = new HashSet<>(Arrays.asList(idList));
			if(set.contains(id)!=true){//判断是否存在歌单里
				idListString=idListString+"&"+id;
			}
		}
		else{
			idListString=id;
		}
		//储存cookie
		Cookie cookie=new Cookie("id",idListString);
		cookie.setMaxAge(60*60*24*30);//设置cookie存活时间,单位秒
		response.addCookie(cookie);
		
		

    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        this.doGet(request, response);
    }
}