package com.itheima.mapper;

import com.itheima.pojo.Song;
import org.apache.ibatis.annotations.Param;
import org.apache.ibatis.annotations.Select;

import java.util.Collection;
import java.util.List;
import java.util.Map;
import java.util.Set;

public interface SongMapper {
	
	List<Song> search(String singer);












}
