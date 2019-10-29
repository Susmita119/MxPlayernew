import React, {Component} from 'react'
import './MxPlayer.css'


class MxPlayer extends Component {

	constructor(props) {
		super (props)

		this.state = {
			header: ["ID", "Song Name", "Default Sequence"],
			songs: []
		}
	}

	getSongs(){
		let promise = fetch('https://localhost:44339/api/SongsTables' ,{
			method: "GET",
			headers: {
				"Content-Type": "application/json"
			}
		});
		return promise;
	}

	componentDidMount(){
		
		this.getSongs()
		.then(response => response.json())
		.then(data => {
			this.setState({songs: data})
		})
	}

	savePlaylist(song){
		const newsong = {id: song.id, PlaySongs: song.songName}
		let promise = fetch('https://localhost:44339/api/AddPlays' ,{
			method: "POST",
			headers: {
				"Content-Type": "application/json"
			},
			body: JSON.stringify(newsong)
		});
		return promise;
	}

	renderTableHeader(){
		// console.log (this.state.header)
		// return header.map((key,index) =>{

		// 	return<th key={index}>{key.toUpperCase()}</th>


		// })

	}
  
  		renderTableData(){ 		

			return this.state.songs.map((song,index) => {
			const{id,songName} = song;
			return(

				<tr key={id}>
				<td>{id}</td>
				<td>{songName}</td>
				<td><button onClick={(e) => this.handleClick(song)}>save</button></td>
				</tr>
				)
		})

	}

	 handleClick = (e) => {
    this.savePlaylist(e)
    .then(res => res.json())
    .then()
  	}


	 render () {
      return (

    <div>
     <button onClick={this.handleClick}>
        save
      </button>
      <h1 id='title'>React Dynamic Table</h1>
      <table id='songs'>
      <tbody>
      <tr>{this.renderTableHeader()}</tr>
      	{this.renderTableData()}
      </tbody>
      </table>
   </div>
    )
  }
}

export default MxPlayer
