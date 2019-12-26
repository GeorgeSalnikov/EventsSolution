import { ApiService } from '../api.service';
import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html',
  styleUrls: ['./event-details.component.css']
})
export class EventDetailsComponent implements OnInit {

  eventdetails = null;
  
  constructor(private apiService: ApiService, private activatedRoute: ActivatedRoute) { }
  //constructor(private router: Router) { }

	ngOnInit() {
		  this.apiService.getEvent(this.activatedRoute.snapshot.params.id).subscribe((data: any)=>{  
			console.log(data);  
			this.eventdetails = data;  
		})  
	}
}
