package com.itheima.web;
import java.util.ArrayList;
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

@WebServlet("/getPlaylist")
/**
 * Mybatis 快速入门代码
 */
public class GetPlaylistServlet extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		Cookie[] cookies= request.getCookies();
		String idListString = "";
		if(cookies!=null){
			for(Cookie cookie:cookies){
				String name=cookie.getName();
				if("id".equals(name)){
					idListString=cookie.getValue();
					break;
				}
			}
			String[] idList=idListString.split("&");
			String resource = "mybatis-config.xml";
			SqlSessionFactory sqlSessionFactory = new SqlSessionFactoryBuilder().build(Resources.getResourceAsReader(resource));
			SqlSession sqlSession = sqlSessionFactory.openSession();
			SongMapper mapper = sqlSession.getMapper(SongMapper.class);
			List<Song> songs=new ArrayList();
			for(String id:idList){
				List<Song> song = mapper.selectById(Integer.valueOf(id).intValue());
				songs.add(song.get(0));
			}
			String jsonString = JSON.toJSONString(songs);
			sqlSession.close();
			response.setContentType("text/html;charset=UTF-8"); 
			response.getWriter().print(jsonString);
		}
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        this.doGet(request, response);
    }
}