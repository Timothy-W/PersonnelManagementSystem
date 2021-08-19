<template>
  <div class="container">
    <div class="container-title">
      <h2>Personnel Tracker</h2>
    </div>
    <PersonnelList
      :personList="personnel"
      @add-person="addNewPerson"
      @delete-person="deletePerson"
      @update-person="updatePerson"
    />
  </div>
</template>

<script>
// @ is an alias to /src
import PersonnelList from "../components/PersonnelListComponents/PersonnelList.vue";

export default {
  name: "Home",
  components: {
    PersonnelList,
  },
  data() {
    return {
      personnel: [],
      //tmpProxy: "https://localhost:5001/"
    };
  },
  methods: {
    async fetchAllPersonnelData() {
      const res = await fetch("api/person");
      const data = await res.json();
      return data;
    },

    async fetchPersonnelData(id) {
      const res = await fetch(`/api/person/${id}`);
      const data = await res.json();
      return data;
    },

    async addNewPerson(person) {
      const res = await fetch(`api/person`, {
        method: "POST",
        headers: {
          "Content-type": "application/json",
        },
        body: JSON.stringify(person),
      });

      const data = await res.json();

      this.personnel = [...this.personnel, data];
    },

    async deletePerson(id) {
      const res = await fetch(`api/person/${id}`, {
        method: "DELETE",
        headers: {
          "Content-type": "application/json",
        },
      });

      res.status === 200
        ? (this.personnel = this.personnel.filter((person) => person.id !== id))
        : alert("Error deleting task");
    },

    async updatePerson(person) {
      const personToUpdate = await this.fetchPersonnelData(person.id);

      const updatedPerson = {
        ...personToUpdate,
        firstName: person.firstName,
        lastName: person.lastName,
        rank: person.rank,
      };

      console.log("updatePerson " + JSON.stringify(updatedPerson));

      const res = await fetch(`api/person/${personToUpdate.id}`, {
        method: "PUT",
        headers: {
          "Content-type": "application/json",
        },
        body: JSON.stringify(updatedPerson),
      });

      const data = await res.json();

      this.personnel = this.personnel.map((element) =>
        element.id === data.id
          ? {
              ...element,
              firstName: data.firstName,
              lastName: data.lastName,
              rank: data.rank,
            }
          : element
      );
    },
  },
  async created() {
    this.personnel = await this.fetchAllPersonnelData();
  },
};
</script>


<style scoped>
.container-title {
  text-align: center;
}
</style>